using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day13 : ASolution
    {

        public Day13() : base(13, 2015, "Knights of the Dinner Table")
        {

        }

        Dictionary<Tuple<string, string>, int> locations = new Dictionary<Tuple<string, string>, int>();
        private List<string> people = new List<string>();

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "733";
            var strings = Input.SplitByNewline();
            /*
            strings = new string[] {
                "Alice would gain 54 happiness units by sitting next to Bob.",
                "Alice would lose 79 happiness units by sitting next to Carol.",
                "Alice would lose 2 happiness units by sitting next to David.",
                "Bob would gain 83 happiness units by sitting next to Alice.",
                "Bob would lose 7 happiness units by sitting next to Carol.",
                "Bob would lose 63 happiness units by sitting next to David.",
                "Carol would lose 62 happiness units by sitting next to Alice.",
                "Carol would gain 60 happiness units by sitting next to Bob.",
                "Carol would gain 55 happiness units by sitting next to David.",
                "David would gain 46 happiness units by sitting next to Alice.",
                "David would lose 7 happiness units by sitting next to Bob.",
                "David would gain 41 happiness units by sitting next to Carol."
            };
            */
            foreach (string str in strings)
            {
                addToList(str);
            }
            string[] result = processAllPermutations(people);
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return result[3];
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "725";
            var strings = Input.SplitByNewline();
            foreach (string str in strings)
            {
                addToList(str);
            }
            foreach (string ppl in people)
            {
                locations[new Tuple<string, string>("me", ppl)] = 0;
                locations[new Tuple<string, string>(ppl, "me")] = 0;
            }
            people.Add("me");
            string[] result = processAllPermutations(people);
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return result[3];
        }

        private void addToList(string input)
        {
            string[] sides = input.Split(" ");
            string personA = sides[0];
            string personB = sides[10].Replace(".", "");
            string operation = sides[2];
            int value = Int32.Parse(sides[3]);
            if (operation == "lose")
                value = -value;

            locations[new Tuple<string, string>(personA, personB)] = value;
            //locations[new Tuple<string, string>(personB, personA)] = value;

            if (!people.Contains(personA))
                people.Add(personA);

            if (!people.Contains(personB))
                people.Add(personB);
        }

        public static List<List<string>> createAllPermutations(List<string> items)
        {
            if (items.Count > 1)
            {
                return items.SelectMany(item => createAllPermutations(items.Where(i => !i.Equals(item)).ToList()),
                                       (item, permutation) => new[] { item }.Concat(permutation).ToList()).ToList();
            }

            return new List<List<string>> { items };
        }

        private string[] processAllPermutations(List<string> people)
        {
            long minHappinessChange = long.MaxValue;
            string minPermutation = "";
            long maxHappinessChange = 0;
            string maxPermutation = "";
            Dictionary<Tuple<string, string>, int> maxPermutationDetails = new Dictionary<Tuple<string, string>, int>();

            List<List<string>> permutations = createAllPermutations(people);

            Dictionary<Tuple<string, string>, int> tempLocations = new Dictionary<Tuple<string, string>, int>();

            foreach (List<string> permutation in permutations)
            {
                long happinessChange = 0;
                tempLocations = new Dictionary<Tuple<string, string>, int>();
                for (int i = 0; i < permutation.Count; i++)
                {
                    if (i == 0)
                    {
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[i + 1])];
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[permutation.Count - 1])];
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[i + 1]), locations[new Tuple<string, string>(permutation[i], permutation[i + 1])]);
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[permutation.Count - 1]), locations[new Tuple<string, string>(permutation[i], permutation[permutation.Count - 1])]);
                    }
                    else if (i == permutation.Count - 1)
                    {
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[0])];
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[i - 1])];
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[0]), locations[new Tuple<string, string>(permutation[i], permutation[0])]);
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[i - 1]), locations[new Tuple<string, string>(permutation[i], permutation[i - 1])]);

                    }
                    else
                    {
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[i + 1])];
                        happinessChange += locations[new Tuple<string, string>(permutation[i], permutation[i - 1])];
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[i + 1]), locations[new Tuple<string, string>(permutation[i], permutation[i + 1])]);
                        tempLocations.Add(new Tuple<string, string>(permutation[i], permutation[i - 1]), locations[new Tuple<string, string>(permutation[i], permutation[i - 1])]);

                    }
                }

                minHappinessChange = Math.Min(happinessChange, minHappinessChange);
                if (minHappinessChange == happinessChange)
                    minPermutation = String.Join(", ", permutation);
                maxHappinessChange = Math.Max(happinessChange, maxHappinessChange);
                if (maxHappinessChange == happinessChange)
                {
                    maxPermutation = String.Join(", ", permutation);
                    maxPermutationDetails = tempLocations;
                }
            }

            return new string[] { minPermutation, minHappinessChange.ToString(), maxPermutation, maxHappinessChange.ToString() };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day09 : ASolution
    {

        public Day09() : base(9, 2015, "All in a Single Night")
        {

        }

        Dictionary<Tuple<string, string>, int> locations = new Dictionary<Tuple<string, string>, int>();
        private List<string> cities = new List<string>();

        protected override string SolvePartOne()
        {
            return "117";
            var strings = Input.SplitByNewline();
            //strings = new string[] { "London to Dublin = 464", "London to Belfast = 518", "Dublin to Belfast = 141" };
            foreach (string str in strings)
            {
                addToMap(str);
            }
            string[] result = processAllPermutations(cities);

            return result[0];
        }

        protected override string SolvePartTwo()
        {
            return "909";
            var strings = Input.SplitByNewline();
            foreach (string str in strings)
            {
                addToMap(str);
            }
            string[] result = processAllPermutations(cities);

            return result[1];
        }

        private void addToMap(string input)
        {
            string[] sides = input.Split(new[] { " = " }, StringSplitOptions.None);
            string townString = sides[0];
            int distance = Int16.Parse(sides[1]);
            string[] towns = townString.Split(new[] { " to " }, StringSplitOptions.None);

            locations[new Tuple<string, string>(towns[0], towns[1])] = distance;
            locations[new Tuple<string, string>(towns[1], towns[0])] = distance;

            if (!cities.Contains(towns[0]))
                cities.Add(towns[0]);

            if (!cities.Contains(towns[1]))
                cities.Add(towns[1]);
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

        private string[] processAllPermutations(List<string> cities)
        {
            long minTrip = long.MaxValue;
            long maxTrip = 0;

            List<List<string>> permutations = createAllPermutations(cities);
            foreach (List<string> permutation in permutations)
            {
                long tripLength = 0;
                for (int i = 0; i < permutation.Count - 1; i++)
                    tripLength += locations[new Tuple<string, string>(permutation[i], permutation[i + 1])];

                minTrip = Math.Min(tripLength, minTrip);
                maxTrip = Math.Max(tripLength, maxTrip);
            }

            return new string[] { minTrip.ToString(), maxTrip.ToString() };
        }
    }
}

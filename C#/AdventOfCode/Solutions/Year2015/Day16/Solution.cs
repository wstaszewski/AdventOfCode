using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2015
{

    class Day16 : ASolution
    {

        public Day16() : base(16, 2015, "Aunt Sue")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "213";
            var strings = Input.SplitByNewline();
            List<Aunt> aunts = new List<Aunt>();
            foreach (string str in strings)
            {
                aunts.Add(new Aunt(str));
            }

            Aunt theOne = aunts.Find(a =>
            (a.Properties["children"] == 3 || a.Properties["children"] == null) &&
            (a.Properties["cats"] == 7 || a.Properties["cats"] == null) &&
            (a.Properties["samoyeds"] == 2 || a.Properties["samoyeds"] == null) &&
            (a.Properties["pomeranians"] == 3 || a.Properties["pomeranians"] == null) &&
            (a.Properties["akitas"] == 0 || a.Properties["akitas"] == null) &&
            (a.Properties["vizslas"] == 0 || a.Properties["vizslas"] == null) &&
            (a.Properties["goldfish"] == 5 || a.Properties["goldfish"] == null) &&
            (a.Properties["trees"] == 3 || a.Properties["trees"] == null) &&
            (a.Properties["cars"] == 2 || a.Properties["cars"] == null) &&
            (a.Properties["perfumes"] == 1 || a.Properties["perfumes"] == null));

            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return theOne.Number.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "323";
            var strings = Input.SplitByNewline();
            List<Aunt> aunts = new List<Aunt>();
            foreach (string str in strings)
            {
                aunts.Add(new Aunt(str));
            }

            Aunt theRealOne = aunts.Find(a =>
            (a.Properties["children"] == 3 || a.Properties["children"] == null) &&
            (a.Properties["cats"] > 7 || a.Properties["cats"] == null) &&
            (a.Properties["samoyeds"] == 2 || a.Properties["samoyeds"] == null) &&
            (a.Properties["pomeranians"] < 3 || a.Properties["pomeranians"] == null) &&
            (a.Properties["akitas"] == 0 || a.Properties["akitas"] == null) &&
            (a.Properties["vizslas"] == 0 || a.Properties["vizslas"] == null) &&
            (a.Properties["goldfish"] < 5 || a.Properties["goldfish"] == null) &&
            (a.Properties["trees"] > 3 || a.Properties["trees"] == null) &&
            (a.Properties["cars"] == 2 || a.Properties["cars"] == null) &&
            (a.Properties["perfumes"] == 1 || a.Properties["perfumes"] == null));

            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return theRealOne.Number.ToString();
        }
    }

    public class Aunt
    {
        public int Number { get; set; }
        public Dictionary<string, Nullable<int>> Properties { get; set; }
        /*
        public int Children { get; set; }
        public int Cats { get; set; }
        public Tuple<string, int> Dogs { get; set; }
        public int Goldfish { get; set; }
        public int Trees { get; set; }
        public int Cars { get; set; }
        public int Perfumes { get; set; }
        */
        public Aunt(string input)
        {
            // Sue 1: children: 1, cars: 8, vizslas: 7
            var firstSplit = input.Split(":");
            this.Number = Int32.Parse(firstSplit[0].Split(" ")[1]);
            string inp = input.Replace("Sue " + this.Number + ": ", "");
            var secondSplit = inp.Replace(" ", "").Split(",");
            this.Properties = new Dictionary<string, Nullable<int>>();
            var list = new string[] { "children", "cats", "samoyeds", "pomeranians", "akitas", "vizslas", "goldfish", "trees", "cars", "perfumes" };
            foreach (string str in list)
            {
                this.Properties.Add(str, null);
            }
            foreach (string str in secondSplit)
            {
                var arr = str.Split(":");
                this.Properties[arr[0]] = Int32.Parse(arr[1]);
                //this.Properties.Add(arr[0], Int32.Parse(arr[1]));
            }

        }
    }
}

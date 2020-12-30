using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day02 : ASolution
    {

        public Day02() : base(2, 2015, "I Was Told There Would Be No Math")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int totalAmmountOfPaper = 0;
            List<string> boxes = Input.SplitByNewline().ToList();
            foreach (string box in boxes)
            {
                string[] lens = box.Split("x");
                PresentBox b = new PresentBox(Int32.Parse(lens[0]), Int32.Parse(lens[1]), Int32.Parse(lens[2]));
                totalAmmountOfPaper += b.getNeededPaper();
            }
            watch.Stop();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return totalAmmountOfPaper.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int totalAmmountOfRibbon = 0;
            List<string> boxes = Input.SplitByNewline().ToList();
            foreach (string box in boxes)
            {
                string[] lens = box.Split("x");
                PresentBox b = new PresentBox(Int32.Parse(lens[0]), Int32.Parse(lens[1]), Int32.Parse(lens[2]));
                totalAmmountOfRibbon += b.getNeededRibbon();
            }
            watch.Stop();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return totalAmmountOfRibbon.ToString();
        }
    }

    class PresentBox
    {
        int neededPaper;
        int neededRibbon;
        List<int> lengths;
        List<int> sides;

        public PresentBox(int l, int w, int h)
        {
            this.lengths = new List<int> { l, w, h };
            this.lengths.Sort();

            int lw = l * w;
            int wh = w * h;
            int hl = h * l;
            this.sides = new List<int> { lw, wh, hl };

            this.neededPaper = 2 * lw + 2 * wh + 2 * hl + sides.Min();
            this.neededRibbon = 2 * this.lengths[0] + 2 * this.lengths[1] + l * w * h;
        }

        public int getNeededPaper()
        {
            return neededPaper;
        }

        public int getNeededRibbon()
        {
            return neededRibbon;
        }
    }
}

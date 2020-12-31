using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day03 : ASolution
    {
        public Day03() : base(3, 2015, "Perfectly Spherical Houses in a Vacuum")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int x = 0;
            int y = 0;
            var hashSet = new HashSet<Tuple<int, int>>();
            hashSet.Add(Tuple.Create(0, 0));
            foreach (var chr in Input)
            {
                x += chr == '>' ? 1 : (chr == '<' ? -1 : 0);
                y += chr == 'v' ? 1 : (chr == '^' ? -1 : 0);
                hashSet.Add(Tuple.Create(x, y));
            }

            watch.Stop();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return hashSet.Count.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int[] positionSanta = new int[] { 0, 0 };
            int[] positionRobot = new int[] { 0, 0 };
            var hashSet = new HashSet<Tuple<int, int>>();
            hashSet.Add(Tuple.Create(0, 0));
            int i = 0;
            foreach (var chr in Input)
            {
                switch(i)
                {
                    case 0:
                        positionSanta[0] += chr == '>' ? 1 : (chr == '<' ? -1 : 0);
                        positionSanta[1] += chr == 'v' ? 1 : (chr == '^' ? -1 : 0);
                        hashSet.Add(Tuple.Create(positionSanta[0], positionSanta[1]));
                        break;
                    case 1:
                        positionRobot[0] += chr == '>' ? 1 : (chr == '<' ? -1 : 0);
                        positionRobot[1] += chr == 'v' ? 1 : (chr == '^' ? -1 : 0);
                        hashSet.Add(Tuple.Create(positionRobot[0], positionRobot[1]));
                        break;
                }

                i = 1 - i;
            }

            watch.Stop();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return hashSet.Count.ToString();
        }
    }
}

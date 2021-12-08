using System;

namespace AdventOfCode.Solutions.Year2015
{

    class Day20 : ASolution
    {
        int Score = 0;
        int[] houses = new int[200000000];
        public Day20() : base(20, 2015, "Infinite Elves and Infinite Houses")
        {
            Score = Int32.Parse(Input);
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "776160";
            int sc = int.MaxValue;
            for (int i = 1; i < Score / 10; i++)
            {
                for (int j = i; j < Score / 10; j += i)
                    if ((houses[j] += i * 10) >= Score)
                        sc = Math.Min(sc, j);
            }
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return sc.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "786240";
            int sc = int.MaxValue;
            for (int i = 1; i < Score / 10; i++)
            {
                for (int j = i, cnt = 0; cnt < 50 && j < Score / 10; j += i, ++cnt)
                    if ((houses[j] += i * 11) >= Score)
                        sc = Math.Min(sc, j);
            }
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return sc.ToString();
        }
    }
}

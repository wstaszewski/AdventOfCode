namespace AdventOfCode.Solutions.Year2015
{

    class Day25 : ASolution
    {
        long X;
        long Y;
        long x = 0;
        long y = 0;


        public Day25() : base(25, 2015, "Let It Snow")
        {
            var strings = Input.Split(" ");
            Y = long.Parse(strings[16].Trim().Replace(",", ""));
            X = long.Parse(strings[18].Trim().Replace(".", ""));
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "8997277";
            long idx = 20151125;
            while (true)
            {
                idx = NextValue(idx);
                x++;
                y--;
                if (y < 0)
                {
                    y = x;
                    x = 0;
                }
                if (y == Y - 1 && x == X - 1)
                {
                    this.TPart1 = watch.ElapsedMilliseconds.ToString();
                    return idx.ToString();
                }
            }

        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return null;
        }

        private long NextValue(long idx)
        {
            idx *= 252533;
            idx %= 33554393;
            return idx;
        }
    }
}

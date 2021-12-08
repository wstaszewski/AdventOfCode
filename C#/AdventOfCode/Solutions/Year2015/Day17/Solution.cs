using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day17 : ASolution
    {

        public Day17() : base(17, 2015, "No Such Thing as Too Much")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "654";
            var strings = Input.SplitByNewline();
            var containers = strings.Select(int.Parse);
            var combinations = new int[151, 21];
            combinations[0, 0] = 1;

            foreach (int container in containers)
            {
                for (int v = 150 - container; v >= 0; v--)
                {
                    for (int n = 20; n > 0; n--)
                    {
                        combinations[v + container, n] += combinations[v, n - 1];
                    }
                }
            }

            int allCombinations = Enumerable.Range(0, 21).Sum(n => combinations[150, n]);

            //int minCount = Enumerable.Range(0, 20).Where(n => counts[150, n] > 0).Min();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return allCombinations.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "57";
            var strings = Input.SplitByNewline();
            var containers = strings.Select(int.Parse);
            var combinations = new int[151, 21];
            combinations[0, 0] = 1;

            foreach (int container in containers)
            {
                for (int v = 150 - container; v >= 0; v--)
                {
                    for (int n = 20; n > 0; n--)
                    {
                        combinations[v + container, n] += combinations[v, n - 1];
                    }
                }
            }

            int allCombinations = Enumerable.Range(0, 21).Sum(n => combinations[150, n]);

            int minCount = Enumerable.Range(0, 20)
                .Where(n => combinations[150, n] > 0)
                .Min();

            int minCombinations = combinations[150, minCount];
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return minCombinations.ToString();
        }
    }
}

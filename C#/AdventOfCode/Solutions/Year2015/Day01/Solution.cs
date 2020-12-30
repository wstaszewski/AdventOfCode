using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day01 : ASolution
    {
        public Day01() : base(1, 2015, "Not Quite Lisp")
        {
        }

        protected override string SolvePartOne()
        {
            //return "232";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int countUp = Input.Count(c => c == '(');
            int countDown = Input.Count(c => c == ')');
            int res = countUp - countDown;
            watch.Stop();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return res.ToString();
        }

        protected override string SolvePartTwo()
        {
            //return "1783";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int position = 1;
            int level = 0;
            foreach (char c in Input.ToCharArray())
            {
                if (c == '(')
                    level++;
                else if (c == ')')
                    level--;

                if (level == -1)
                    break;
                position++;
            }
            watch.Stop();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return position.ToString();
        }
    }
}

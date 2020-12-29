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
            int countUp = Input.Count(c => c == '(');
            int countDown = Input.Count(c => c == ')');
            int res = countUp - countDown;
            return res.ToString();
        }

        protected override string SolvePartTwo()
        {
            //return "1783";
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

            return position.ToString();
        }
    }
}

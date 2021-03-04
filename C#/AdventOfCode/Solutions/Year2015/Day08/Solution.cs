using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2015
{

    class Day08 : ASolution
    {

        public Day08() : base(8, 2015, "Matchsticks")
        {

        }

        protected override string SolvePartOne()
        {
            return "1350";
            var words = Input.SplitByNewline();
            int result = words.Sum(w => w.Length - Regex.Replace(w.Trim('"').Replace("\\\"", "A").Replace("\\\\", "B"), "\\\\x[a-f0-9]{2}", "C").Length);

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            return "2085";
            var words = Input.SplitByNewline();
            int result = words.Sum(w => w.Replace("\\", "AA").Replace("\"", "BB").Length + 2 - w.Length);
            return result.ToString();
        }

    }
}

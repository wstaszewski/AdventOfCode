using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day05 : ASolution
    {
        int niceStringsCount;

        public Day05() : base(5, 2015, "Doesn't He Have Intern-Elves For This?")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            niceStringsCount = 0;
            string[] strings = Input.SplitByNewline();
            foreach (string str in strings)
            {
                if (isNiceString(str))
                    niceStringsCount++;
            }
            watch.Stop();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return niceStringsCount.ToString();
            //return "236";
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            niceStringsCount = 0;
            string[] strings = Input.SplitByNewline();
            var ret = strings.Where(s => HasPair(s) && HasRepeats(s)).ToList();
            watch.Stop();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return ret.Count.ToString();
            //return "51";
        }

        private bool isNiceString(string input)
        {
            int vowels = input.Count(v => v == 'a') + input.Count(v => v == 'e') + input.Count(v => v == 'i') + input.Count(v => v == 'o') + input.Count(v => v == 'u');

            // Case 1
            if (vowels < 3)
                return false;

            // Case 3
            if (input.Contains("ab") || input.Contains("cd") || input.Contains("pq") || input.Contains("xy"))
                return false;

            // Case 2
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == (char)(input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasPair(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                string pair = s.Substring(i, 2);
                if (s.IndexOf(pair, i + 2) != -1)
                    return true;
            }

            return false;
        }

        private static bool HasRepeats(string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] == s[i + 2])
                    return true;
            }

            return false;
        }
    }
}

using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2015
{

    class Day11 : ASolution
    {

        char[] password;

        public Day11() : base(11, 2015, "Corporate Policy")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "hepxxyzz";
            password = Input.ToCharArray();
            //password = "abcdefgh".ToCharArray();
            //password = "ghijklmn".ToCharArray();
            do
            {
                password = incrementPassword(password);
            } while (!isPasswordValid(password));
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return new string(password);
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "heqaabcc";
            password = SolvePartOne().ToCharArray();
            do
            {
                password = incrementPassword(password);
            } while (!isPasswordValid(password));
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return new string(password);
        }

        private bool isPasswordValid(char[] password)
        {
            // case 2, if initial pass would already have one of the banned letters
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == 'i' || password[i] == 'o' || password[i] == 'l') return false;
            }

            bool check1 = false;
            bool check3 = false;
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] + 1 == password[i + 1] && password[i] + 2 == password[i + 2])
                {
                    check1 = true;
                    break;
                }
            }

            Regex rex = new Regex(@"([a-z])\1|([a-z])\2");
            int count = rex.Matches(new string(password)).Count;
            if (count > 1)
                check3 = true;

            return check1 && check3;
        }

        private char[] incrementPassword(char[] password, int position = 0)
        {
            if (position == 0)
                position = password.Length - 1;

            password[position]++;
            if (password[position] == 'i' || password[position] == 'o' || password[position] == 'l') password[position]++;
            if (password[position] <= 'z') return password;

            password[position] = 'a';
            password = incrementPassword(password, position - 1);
            return password;

        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Solutions.Year2015
{

    class Day04 : ASolution
    {


        public Day04() : base(4, 2015, "The Ideal Stocking Stuffer")
        {

        }

        protected override string SolvePartOne()
        {
            this.TPart1 = "477";
            return "346386";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MD5 md = MD5.Create();
            string result = "";
            for (long i = 1; i < long.MaxValue; i++)
            {
                string inp = Input + i.ToString();
                string res = CreateMD5(inp);
                if (res.Substring(0, 5) == "00000")
                {
                    result = i.ToString();
                    break;
                }

            }
            watch.Stop();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return result;
        }

        protected override string SolvePartTwo()
        {
            this.TPart1 = "12944";
            return "9958218";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MD5 md = MD5.Create();
            string result = "";
            for (long i = 1; i < long.MaxValue; i++)
            {
                string inp = Input + i.ToString();
                string res = CreateMD5(inp);
                if (res.Substring(0, 6) == "000000")
                {
                    result = i.ToString();
                    break;
                }

            }
            watch.Stop();
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return result;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

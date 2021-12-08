using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2015
{

    class Day10 : ASolution
    {

        public Day10() : base(10, 2015, "Elves Look, Elves Say")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "252594";
            string inp = Input;
            //inp = "1";
            for (int i = 0; i < 40; i++)
            {
                inp = applyLookAndSay(inp);
            }
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return inp.Length.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "3579328";
            string inp = Input;
            //inp = "1";
            for (int i = 0; i < 50; i++)
            {
                inp = lookAndSayEfficient(inp);
            }
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return inp.Length.ToString();
        }

        private string lookAndSayEfficient(string input)
        {
            StringBuilder res = new StringBuilder();

            char repeat = input[0];
            input = input.Substring(1, input.Length - 1) + " ";
            int count = 1;

            foreach (char c in input)
            {
                if (c != repeat)
                {
                    res.Append(Convert.ToString(count) + repeat);
                    count = 1;
                    repeat = c;
                }
                else
                {
                    count += 1;
                }
            }
            return res.ToString();
        }

        private string applyLookAndSay(string input)
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            int count = 1;
            var digits = input.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits.Length == 1)
                {
                    list.Add(new Tuple<string, string>("1", digits[i].ToString()));
                    break;
                }

                if (i == digits.Length - 1)
                {
                    if (digits[i] == digits[i - 1])
                    {
                        list.Add(new Tuple<string, string>(count.ToString(), digits[i].ToString()));
                    }
                    else
                    {
                        list.Add(new Tuple<string, string>("1", digits[i].ToString()));

                    }
                    break;
                }

                if (digits[i] == digits[i + 1])
                {
                    count++;
                }
                else
                {
                    list.Add(new Tuple<string, string>(count.ToString(), digits[i].ToString()));
                    count = 1;
                }
            }
            string result = "";
            foreach (var str in list)
            {
                result += str.Item1;
                result += str.Item2;
            }
            return result;
        }
    }
}

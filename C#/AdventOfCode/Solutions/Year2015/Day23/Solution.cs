using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2015
{

    class Day23 : ASolution
    {

        public Day23() : base(23, 2015, "Opening the Turing Lock")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "184";
            string[] input = Input.SplitByNewline();
            IDictionary<string, uint> registers = new Dictionary<string, uint>();
            registers["a"] = 0;
            registers["b"] = 0;

            int instruction = 0;
            while (instruction >= 0 && instruction < input.Length)
            {
                string[] words = input[instruction].Split(' ', ',');
                switch (words[0])
                {
                    case "hlf":
                        registers[words[1]] /= 2;
                        instruction++;
                        break;

                    case "tpl":
                        registers[words[1]] *= 3;
                        instruction++;
                        break;

                    case "inc":
                        registers[words[1]] += 1;
                        instruction++;
                        break;

                    case "jmp":
                        instruction += int.Parse(words[1]);
                        break;

                    case "jie":
                        if (registers[words[1]] % 2 == 0)
                        {
                            instruction += int.Parse(words[3]);
                        }
                        else
                        {
                            instruction++;
                        }
                        break;

                    case "jio":
                        if (registers[words[1]] == 1)
                        {
                            instruction += int.Parse(words[3]);
                        }
                        else
                        {
                            instruction++;
                        }
                        break;
                }
            }
            var result = registers["b"];
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "231";
            string[] input = Input.SplitByNewline();
            IDictionary<string, uint> registers = new Dictionary<string, uint>();
            registers["a"] = 1;
            registers["b"] = 0;

            int instruction = 0;
            while (instruction >= 0 && instruction < input.Length)
            {
                string[] words = input[instruction].Split(' ', ',');
                switch (words[0])
                {
                    case "hlf":
                        registers[words[1]] /= 2;
                        instruction++;
                        break;

                    case "tpl":
                        registers[words[1]] *= 3;
                        instruction++;
                        break;

                    case "inc":
                        registers[words[1]] += 1;
                        instruction++;
                        break;

                    case "jmp":
                        instruction += int.Parse(words[1]);
                        break;

                    case "jie":
                        if (registers[words[1]] % 2 == 0)
                        {
                            instruction += int.Parse(words[3]);
                        }
                        else
                        {
                            instruction++;
                        }
                        break;

                    case "jio":
                        if (registers[words[1]] == 1)
                        {
                            instruction += int.Parse(words[3]);
                        }
                        else
                        {
                            instruction++;
                        }
                        break;
                }
            }
            var result = registers["b"];
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }
    }
}

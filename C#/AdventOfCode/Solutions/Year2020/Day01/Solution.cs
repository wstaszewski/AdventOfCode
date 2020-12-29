using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {
        List<int> list = new List<int>();
        public Day01() : base(1, 2020, "Report Repair")
        {
            var strings = Input.SplitByNewline();
            foreach (string str in strings)
                list.Add(Int32.Parse(str));
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] + list[j] == 2020)
                    {
                        watch.Stop();
                        this.TPart1 = watch.ElapsedMilliseconds.ToString();
                        return (list[i] * list[j]).ToString();
                    }
                }
            }
            return null;
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[i] + list[j] + list[k] == 2020)
                        {
                            watch.Stop();
                            this.TPart2 = watch.ElapsedMilliseconds.ToString();
                            return (list[i] * list[j] * list[k]).ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}

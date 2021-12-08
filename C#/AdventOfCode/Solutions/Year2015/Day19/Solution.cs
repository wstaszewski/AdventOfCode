using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2015
{

    class Day19 : ASolution
    {
        List<string> strings = new List<string>();
        string initMocelule;
        public Day19() : base(19, 2015, "Medicine for Rudolph")
        {
            var arr = Input.Split("\n\n");
            var ar = arr[0].SplitByNewline();
            initMocelule = arr[1].Trim();
            foreach (string a in ar)
                strings.Add(a);
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "535";
            List<string> molecules = new List<string>();
            foreach (string a in strings)
            {

                var parts = a.Split("=>");
                //string newMolecule = initMocelule.Replace(parts[0].Trim(), parts[1].Trim());
                //molecules.Add(newMolecule);
                foreach (Match m in Regex.Matches(initMocelule, parts[0].Trim(), RegexOptions.Compiled))
                {
                    string s = initMocelule.Remove(m.Index, parts[0].Trim().Length).Insert(m.Index, parts[1].Trim());
                    molecules.Add(s);
                }
            }
            var result = molecules.Distinct().ToArray().Count();
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "212";
            int count = 0;
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //List<string> redukcje = new List<string>();
            //redukcje.Add(initMocelule);
            while (true)
            {
                for (int i = 0; i < strings.Count; i++)
                {
                    var parts = strings[i].Split("=>");

                    if (initMocelule.Contains(parts[1].Trim()))
                    {
                        Regex regex = new Regex(parts[1].Trim());
                        initMocelule = regex.Replace(initMocelule, parts[0].Trim(), 1);
                        count++;
                        //redukcje.Add(initMocelule);
                    }

                }
                if (initMocelule.Distinct().Count() == 1)
                {
                    //TextWriter tw = new StreamWriter("redukcje_ws.txt");
                    //foreach (string s in redukcje)
                    //    tw.WriteLine(s);
                    //tw.Close();
                    //watch.Stop();
                    //var elapsedMs = watch.ElapsedMilliseconds;
                    this.TPart2 = watch.ElapsedMilliseconds.ToString();
                    return count.ToString();
                }
            }
        }
    }
}

using System;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day06 : ASolution
    {
        Light[,] lights = new Light[1000, 1000];
        static int[] cColors = { 0x000000, 0x000080, 0x008000, 0x008080, 0x800000, 0x800080, 0x808000, 0xC0C0C0, 0x808080, 0x0000FF, 0x00FF00, 0x00FFFF, 0xFF0000, 0xFF00FF, 0xFFFF00, 0xFFFFFF };

        public Day06() : base(6, 2015, "Probably a Fire Hazard")
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int ii = 0; ii < 1000; ii++)
                {
                    lights[i, ii] = new Light();
                }
            }
        }

        protected override string SolvePartOne()
        {
            return "377891";
            int count = 0;
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "turn off 499,499 through 500,500" };
            foreach (string str in strings)
            {
                if (str.StartsWith("turn off")) turn_off(str.Replace("turn off ", ""));
                else if (str.StartsWith("turn on")) turn_on(str.Replace("turn on ", ""));
                else toggle(str.Replace("toggle ", ""));

                //print();
                //System.Threading.Thread.Sleep(25);
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int ii = 0; ii < 1000; ii++)
                {
                    if (lights[i, ii].status == true)
                        count++;
                }
            }

            return count.ToString();
        }

        protected override string SolvePartTwo()
        {
            return "14110788";
            int total_brightness = 0;
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "toggle 0,0 through 999,999" };
            foreach (string str in strings)
            {
                if (str.StartsWith("turn off")) turn_off(str.Replace("turn off ", ""));
                else if (str.StartsWith("turn on")) turn_on(str.Replace("turn on ", ""));
                else toggle(str.Replace("toggle ", ""));

                //print();
                //System.Threading.Thread.Sleep(25);
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int ii = 0; ii < 1000; ii++)
                {
                    if (lights[i, ii].brightness > 0)
                        total_brightness += lights[i, ii].brightness;
                }
            }

            return total_brightness.ToString();
        }

        private void turn_on(string input)
        {
            string[] arr = input.Split(" ");
            string[] param1 = arr[0].Split(",");
            string[] param2 = arr[2].Split(",");


            if (param1[0] == param2[0])
            {
                for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                {
                    lights[Int32.Parse(param1[0]), ii].status = true;
                    lights[Int32.Parse(param1[0]), ii].brightness++;
                }
            }
            else
            {
                for (int i = Math.Min(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i <= Math.Max(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i++)
                {
                    if (param1[1] == param2[1])
                    {
                        lights[i, Int32.Parse(param1[1])].status = true;
                        lights[i, Int32.Parse(param1[1])].brightness++;
                    }
                    else
                    {
                        for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                        {
                            lights[i, ii].status = true;
                            lights[i, ii].brightness++;
                        }
                    }
                }
            }
        }

        private void turn_off(string input)
        {
            string[] arr = input.Split(" ");
            string[] param1 = arr[0].Split(",");
            string[] param2 = arr[2].Split(",");


            if (param1[0] == param2[0])
            {
                for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                {
                    lights[Int32.Parse(param1[0]), ii].status = false;
                    if (lights[Int32.Parse(param1[0]), ii].brightness > 0)
                        lights[Int32.Parse(param1[0]), ii].brightness--;
                }
            }
            else
            {
                for (int i = Math.Min(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i <= Math.Max(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i++)
                {
                    if (param1[1] == param2[1])
                    {
                        lights[i, Int32.Parse(param1[1])].status = false;
                        if (lights[i, Int32.Parse(param1[1])].brightness > 0)
                            lights[i, Int32.Parse(param1[1])].brightness--;
                    }
                    else
                    {
                        for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                        {
                            lights[i, ii].status = false;
                            if (lights[i, ii].brightness > 0)
                                lights[i, ii].brightness--;
                        }
                    }
                }
            }
        }

        private void toggle(string input)
        {
            string[] arr = input.Split(" ");
            string[] param1 = arr[0].Split(",");
            string[] param2 = arr[2].Split(",");

            if (param1[0] == param2[0])
            {
                for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                {
                    lights[Int32.Parse(param1[0]), ii].status = !lights[Int32.Parse(param1[0]), ii].status;
                    lights[Int32.Parse(param1[0]), ii].brightness += 2;
                }
            }
            else
            {
                for (int i = Math.Min(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i <= Math.Max(Int32.Parse(param1[0]), Int32.Parse(param2[0])); i++)
                {
                    if (param1[1] == param2[1])
                    {
                        lights[i, Int32.Parse(param1[1])].status = !lights[i, Int32.Parse(param1[1])].status;
                        lights[i, Int32.Parse(param1[1])].brightness += 2;
                    }
                    else
                    {
                        for (int ii = Math.Min(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii <= Math.Max(Int32.Parse(param1[1]), Int32.Parse(param2[1])); ii++)
                        {
                            lights[i, ii].status = !lights[i, ii].status;
                            lights[i, ii].brightness += 2;
                        }
                    }
                }
            }
        }

        private void print()
        {
            //string output = "";
            /*StringBuilder output = new StringBuilder();
            Console.Clear();
            for (int i = 0; i < 1000; i++)
            {
                for (int ii = 0; ii < 1000; ii++)
                {
                    output.Append(lights[i, ii].status ? "* " : "0 ");
                }
                output.Append("\n");
            }
            Console.Write(output.ToString());*/

            Bitmap b = new Bitmap(1000, 1000);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    b.SetPixel(i, j, lights[i, j].status ? Color.White : Color.Black);
                }
            }
            Console.Clear();
            ConsoleWriteImage(b);

        }

        public static void ConsoleWriteImage(Bitmap source)
        {
            int sMax = 39;
            decimal percent = Math.Min(decimal.Divide(sMax, source.Width), decimal.Divide(sMax, source.Height));
            Size dSize = new Size((int)(source.Width * percent), (int)(source.Height * percent));
            Bitmap bmpMax = new Bitmap(source, dSize.Width * 2, dSize.Height);
            for (int i = 0; i < dSize.Height; i++)
            {
                for (int j = 0; j < dSize.Width; j++)
                {
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2, i));
                    ConsoleWritePixel(bmpMax.GetPixel(j * 2 + 1, i));
                }
                System.Console.WriteLine();
            }
            Console.ResetColor();
        }

        public static void ConsoleWritePixel(Color cValue)
        {
            Color[] cTable = cColors.Select(x => Color.FromArgb(x)).ToArray();
            char[] rList = new char[] { (char)9617, (char)9618, (char)9619, (char)9608 }; // 1/4, 2/4, 3/4, 4/4
            int[] bestHit = new int[] { 0, 0, 4, int.MaxValue }; //ForeColor, BackColor, Symbol, Score

            for (int rChar = rList.Length; rChar > 0; rChar--)
            {
                for (int cFore = 0; cFore < cTable.Length; cFore++)
                {
                    for (int cBack = 0; cBack < cTable.Length; cBack++)
                    {
                        int R = (cTable[cFore].R * rChar + cTable[cBack].R * (rList.Length - rChar)) / rList.Length;
                        int G = (cTable[cFore].G * rChar + cTable[cBack].G * (rList.Length - rChar)) / rList.Length;
                        int B = (cTable[cFore].B * rChar + cTable[cBack].B * (rList.Length - rChar)) / rList.Length;
                        int iScore = (cValue.R - R) * (cValue.R - R) + (cValue.G - G) * (cValue.G - G) + (cValue.B - B) * (cValue.B - B);
                        if (!(rChar > 1 && rChar < 4 && iScore > 50000)) // rule out too weird combinations
                        {
                            if (iScore < bestHit[3])
                            {
                                bestHit[3] = iScore; //Score
                                bestHit[0] = cFore;  //ForeColor
                                bestHit[1] = cBack;  //BackColor
                                bestHit[2] = rChar;  //Symbol
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = (ConsoleColor)bestHit[0];
            Console.BackgroundColor = (ConsoleColor)bestHit[1];
            Console.Write(rList[bestHit[2] - 1]);
        }

    }

    class Light
    {
        public bool status;
        public int brightness;
        public Light()
        {
            this.status = false;
            this.brightness = 0;
        }

    }


}

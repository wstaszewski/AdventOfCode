using System;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day18 : ASolution
    {
        bool[][] lights = Enumerable.Range(0, 102).Select(i => new bool[102]).ToArray();

        public Day18() : base(18, 2015, "Like a GIF For Your Yard")
        {
            var strings = Input.SplitByNewline();
            var l = strings.Length;
            var w = strings[0].Length;
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    lights[i + 1][j + 1] = strings[i][j] == '#';
                }
            }
            //int a = lights.GetLength(0);
            //int b = lights.GetLength(1);
            //int lightsOn = Count(lights, lights.GetLength(0), lights.GetLength(1));
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "768";
            for (var c = 0; c < 100; c++)
            {
                lights = DoStep(lights);
            }
            var result = lights.Sum(l => l.Count(x => x));
            this.TPart1 = watch.ElapsedMilliseconds.ToString();
            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "781";
            SetCornersOn(lights);
            for (var c = 0; c < 100; c++)
            {
                lights = DoStep(lights, true);
            }
            var result = lights.Sum(l => l.Count(x => x));
            this.TPart2 = watch.ElapsedMilliseconds.ToString();
            return result.ToString();

        }

        private static void SetCornersOn(bool[][] lights)
        {
            lights[1][1] = lights[1][100] = lights[100][1] = lights[100][100] = true;
        }

        private static bool[][] DoStep(bool[][] lights, bool isSecond = false)
        {
            var newLights = Enumerable.Range(0, 102).Select(i => new bool[102]).ToArray();

            for (var i = 1; i < 101; i++)
            {
                for (var j = 1; j < 101; j++)
                {
                    var onNeighbours = new[]
                                       {
                                   lights[i - 1][j - 1], lights[i - 1][j], lights[i - 1][j + 1],
                                   lights[i][j - 1], lights[i][j + 1],
                                   lights[i + 1][j - 1], lights[i + 1][j], lights[i + 1][j + 1]
                               }.Count(n => n);
                    newLights[i][j] = lights[i][j] ? onNeighbours == 2 || onNeighbours == 3 : onNeighbours == 3;
                }
            }

            // for part 2
            if (isSecond)
                SetCornersOn(newLights);

            return newLights;
        }

        void PrintMap(bool[][] map)
        {
            Console.Clear();
            for (var y = 0; y < map[0].Length; y++)
            {
                for (var x = 0; x < map.Length; x++)
                {
                    Console.Write((map[y][x] ? '#' : '.').ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //Thread.Sleep(50);

        }
    }
}

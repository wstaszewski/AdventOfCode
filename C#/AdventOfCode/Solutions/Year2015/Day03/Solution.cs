using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day03 : ASolution
    {
        HashSet<House> visitedHouses;
        int globalX;
        int globalY;
        int globalXS;
        int globalYS;
        int step;

        public Day03() : base(3, 2015, "Perfectly Spherical Houses in a Vacuum")
        {

        }

        protected override string SolvePartOne()
        {
            visitedHouses = new HashSet<House>();
            globalX = 0;
            globalY = 0;
            visitedHouses.Add(new House(0, 0));
            char[] coordinates = Input.ToCharArray();
            foreach (char coord in coordinates)
            {
                switch (coord)
                {
                    case '>':
                        globalX++;
                        break;
                    case '<':
                        globalX--;
                        break;
                    case '^':
                        globalY++;
                        break;
                    case 'v':
                        globalY--;
                        break;
                }
                House h = new House(globalX, globalY);
                if (visitedHouses.Any(hh => hh.x == h.x && hh.y == h.y))
                    visitedHouses.First(hh => hh.x == h.x && hh.y == h.y).incrementHowManyPresents();
                else
                    visitedHouses.Add(h);
            }

            return visitedHouses.Count.ToString();
        }

        protected override string SolvePartTwo()
        {
            visitedHouses = new HashSet<House>();
            globalX = 0;
            globalY = 0;
            globalXS = 0;
            globalYS = 0;
            step = 0;
            visitedHouses.Add(new House(0, 0));
            char[] coordinates = Input.ToCharArray();
            foreach (char coord in coordinates)
            {
                step++;
                if (step % 2 == 0)
                {
                    switch (coord)
                    {
                        case '>':
                            globalX++;
                            break;
                        case '<':
                            globalX--;
                            break;
                        case '^':
                            globalY++;
                            break;
                        case 'v':
                            globalY--;
                            break;
                    }
                    House h = new House(globalX, globalY);
                    if (visitedHouses.Any(hh => hh.x == h.x && hh.y == h.y))
                        visitedHouses.First(hh => hh.x == h.x && hh.y == h.y).incrementHowManyPresents();
                    else
                        visitedHouses.Add(h);
                }
                else
                {
                    switch (coord)
                    {
                        case '>':
                            globalXS++;
                            break;
                        case '<':
                            globalXS--;
                            break;
                        case '^':
                            globalYS++;
                            break;
                        case 'v':
                            globalYS--;
                            break;
                    }
                    House h = new House(globalXS, globalYS);
                    if (visitedHouses.Any(hh => hh.x == h.x && hh.y == h.y))
                        visitedHouses.First(hh => hh.x == h.x && hh.y == h.y).incrementHowManyPresents();
                    else
                        visitedHouses.Add(h);
                }

            }

            return visitedHouses.Count.ToString();
        }
    }

    class House
    {
        public int x, y;
        int howManyPresents = 0;

        public House(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getHowManyPresents()
        {
            return this.howManyPresents;
        }

        public void incrementHowManyPresents()
        {
            this.howManyPresents++;
        }
    }
}

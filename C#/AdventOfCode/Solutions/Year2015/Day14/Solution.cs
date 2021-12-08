using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day14 : ASolution
    {

        public Day14() : base(14, 2015, "Reindeer Olympics")
        {

        }

        List<Reindeer> reindeers = new List<Reindeer>();

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "2640";
            int seconds = 2503;
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.", "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds." };
            foreach (string str in strings)
            {
                reindeers.Add(new Reindeer(str));
            }
            int result = reindeers.Max(r => r.CalculateDistance(seconds));
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "1102";
            int seconds = 2503;
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.", "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds." };
            foreach (string str in strings)
            {
                reindeers.Add(new Reindeer(str));
            }
            for (int i = 1; i < seconds + 1; i++)
            {
                foreach (Reindeer r in reindeers)
                {
                    r.CalculateDistance(i);
                }
                reindeers.Sort((p, q) => p.Distance.CompareTo(q.Distance));

                int max = reindeers[reindeers.Count - 1].Distance;

                foreach (Reindeer r in reindeers)
                {
                    if (r.Distance == max)
                        r.Score++;
                }
            }

            reindeers.Sort((p, q) => p.Score.CompareTo(q.Score));
            int result = reindeers[reindeers.Count - 1].Score;

            // 1102
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }
    }

    public class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int FlightTime { get; set; }
        public int RestTime { get; set; }
        public int Distance { get; protected set; }
        public int Score { get; set; }

        public Reindeer(string input)
        {
            var words = input.Split(' ');
            Name = words[0].ToString();
            Speed = Int32.Parse(words[3]);
            FlightTime = Int32.Parse(words[6]);
            RestTime = Int32.Parse(words[13]);
            Score = 0;
        }

        public int CalculateDistance(int time)
        {
            var cycleLength = this.FlightTime + this.RestTime;
            var numberOfCycles = time / cycleLength;
            var excessFlightTime = Math.Min(this.FlightTime, time % cycleLength);
            this.Distance = ((numberOfCycles * this.FlightTime) + excessFlightTime) * this.Speed;
            return this.Distance;
        }
    }
}

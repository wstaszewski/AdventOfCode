using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day12 : ASolution
    {

        public Day12() : base(12, 2015, "JSAbacusFramework.io")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "119433";
            string input = Input;
            dynamic json = JsonConvert.DeserializeObject(input);//JObject.Parse(input);
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return getSum(json).ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "68466";
            string input = Input;
            dynamic json = JsonConvert.DeserializeObject(input);//JObject.Parse(input);
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return getSum(json, "red").ToString();
        }

        long getSum(JObject obj, string banned = "")
        {
            bool shouldAvoid = obj.Properties().Select(o => o.Value).OfType<JValue>().Select(v => v.Value).Contains(banned);
            if (shouldAvoid) return 0;

            return obj.Properties().Sum((dynamic o) => (long)getSum(o.Value, banned));
        }

        long getSum(JArray arr, string banned)
        {
            return arr.Sum((dynamic o) => (long)getSum(o, banned));
        }

        long getSum(JValue val, string banned)
        {
            return val.Type == JTokenType.Integer ? (long)val.Value : 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Solutions.Year2015
{

    class Day24 : ASolution
    {

        public Day24() : base(24, 2015, "It Hangs in the Balance")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "10439961859";
            string[] strings = Input.SplitByNewline();
            var counter = strings.Sum(long.Parse);
            var ints = strings.Select(long.Parse).ToList();
            var size = counter / 3;

            long min = long.MaxValue;

            //var aa = MinProduct(ints.ToArray(), counter / 3, 0, 1, 0);

            var permutations = Distribute(new List<long>(), ints, size);

            permutations.ToList().Sort((a, b) => a.Count - b.Count);
            var perm = permutations.Last();
            var shortest = permutations.Where(p => p.Count == perm.Count);
            foreach (var permutation in shortest)
            {
                var sum = permutation.Sum();
                if (sum == size)
                {
                    var prd = permutation.Aggregate((acc, val) => acc * val);
                    min = Math.Min(min, prd);
                }
            }

            //List<List<int>> permutations = createAllPermutations(ints, size);
            /*var permutations = GetPowerSet(ints, size);
            int aa = permutations.Count();
            int min = int.MaxValue;
            permutations.ToList().Sort((a, b) => a.Count - b.Count);
            var perm = permutations.Last();
            var shortest = permutations.Where(p => p.Count == perm.Count);
            foreach (var permutation in shortest)
            {
                var sum = permutation.Sum();
                if (sum == size)
                {
                    var prd = permutation.Aggregate((acc, val) => acc * val);
                    min = Math.Min(min, prd);
                }
            }*/

            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return min.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "72050269";
            string[] strings = Input.SplitByNewline();
            var counter = strings.Sum(long.Parse);
            var ints = strings.Select(long.Parse).ToList();
            var size = counter / 4;

            long min = long.MaxValue;

            var permutations = Distribute(new List<long>(), ints, size);

            permutations.ToList().Sort((a, b) => a.Count - b.Count);
            var perm = permutations.Last();
            var shortest = permutations.Where(p => p.Count == perm.Count);
            foreach (var permutation in shortest)
            {
                var sum = permutation.Sum();
                if (sum == size)
                {
                    var prd = permutation.Aggregate((acc, val) => acc * val);
                    min = Math.Min(min, prd);
                }
            }
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return min.ToString();
        }

        IEnumerable<List<long>> Distribute(List<long> used, List<long> notused, long size, long best = long.MaxValue)
        {
            if (used.Count >= best) yield break;

            var remaining = size - used.Sum();
            for (int n = 0; n < notused.Count; n++)
            {
                var s = notused[n];
                if (notused[n] > remaining) continue;
                var x = used.ToList();
                x.Add(s);
                if (s == remaining)
                {
                    if (x.Count < best)
                        best = x.Count;
                    yield return x;
                }
                else
                {
                    var y = notused.Skip(n + 1).ToList();
                    foreach (var d in Distribute(x, y, size))
                    {
                        yield return d;
                    }
                }
            }
        }

        public IEnumerable<List<int>> GetPowerSet(List<int> list, int target)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                       //because doing a count will iterate through the enumerable 
                       //better to just convert it to a list up front 
                   let setResult = (from i in Enumerable.Range(0, list.Count)
                                    where (m & (1 << i)) != 0
                                    select list[i]).ToList()
                   where setResult.Sum() == target
                   select setResult.ToList();
        }

        public static List<List<int>> createAllPermutations(List<int> items, int target)
        {
            if (items.Count > 1)
            {
                return items.SelectMany(item => createAllPermutations(items.Where(i => !i.Equals(item)).ToList(), target),
                                       (item, permutation) => new[] { item }.Concat(permutation).ToList()).Where(items => items.Sum() == target).ToList();
            }

            return new List<List<int>> { items };
        }

        static BigInteger MinProduct(int[] inputs, int weightrequirement, int index, BigInteger cumulativeproduct, int cumulativeweight)
        {
            if (cumulativeweight == weightrequirement)
                return cumulativeproduct;
            if (index >= inputs.Length || cumulativeweight > weightrequirement)
            {
                return BigInteger.MinusOne;
            }
            var lhs = MinProduct(inputs, weightrequirement, index + 1, cumulativeproduct * inputs[index], cumulativeweight + inputs[index]);
            var rhs = MinProduct(inputs, weightrequirement, index + 1, cumulativeproduct, cumulativeweight);
            if (lhs == BigInteger.MinusOne) return rhs;
            if (rhs == BigInteger.MinusOne) return lhs;
            return BigInteger.Min(lhs, rhs);
        }

    }
}

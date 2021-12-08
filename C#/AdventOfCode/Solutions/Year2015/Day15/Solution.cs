using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day15 : ASolution
    {

        public Day15() : base(15, 2015, "Science for Hungry People")
        {

        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "21367368";
            var strings = Input.SplitByNewline();
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (string str in strings)
            {
                ingredients.Add(CreateIngredient(str));
            }

            int result = FindMaximum(ingredients, 100, new Ingredient());
            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "1766400";
            var strings = Input.SplitByNewline();
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (string str in strings)
            {
                ingredients.Add(CreateIngredient(str));
            }

            int result = FindMaximumWithCaloriesLimit(ingredients, 100, new Ingredient());
            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return result.ToString();
        }

        private Ingredient CreateIngredient(string text)
        {
            var words = text.Replace(",", "").Split(' ');
            return new Ingredient
            {
                Capacity = Int32.Parse(words[2]),
                Durability = Int32.Parse(words[4]),
                Flavor = Int32.Parse(words[6]),
                Texture = Int32.Parse(words[8]),
                Calories = Int32.Parse(words[10])
            };
        }

        private int FindMaximum(IEnumerable<Ingredient> spareIngredients, int spoons, Ingredient prevIngredient)
        {
            var ingredients = spareIngredients.ToArray();
            var firstIngredient = ingredients.First();
            if (ingredients.Count() == 1)
            {
                var total = prevIngredient.AddTo(firstIngredient.MultiplyBy(spoons));
                return total.Score;
            }

            return Enumerable.Range(0, spoons + 1)
                             .Max(i => FindMaximum(ingredients.Skip(1),
                                 spoons - i,
                                 prevIngredient.AddTo(firstIngredient.MultiplyBy(i))));
        }

        private int FindMaximumWithCaloriesLimit(IEnumerable<Ingredient> spareIngredients, int spoons, Ingredient prevIngredient)
        {
            var ingredients = spareIngredients.ToArray();
            var firstIngredient = ingredients.First();
            if (ingredients.Count() == 1)
            {
                var total = prevIngredient.AddTo(firstIngredient.MultiplyBy(spoons));
                return total.Calories == 500 ? total.Score : 0;
            }

            return Enumerable.Range(0, spoons + 1)
                             .Max(i => FindMaximumWithCaloriesLimit(ingredients.Skip(1),
                                 spoons - i,
                                 prevIngredient.AddTo(firstIngredient.MultiplyBy(i))));
        }

    }

    public class Ingredient
    {
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavor { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }

        public Ingredient AddTo(Ingredient other)
        {
            return new Ingredient
            {
                Capacity = Capacity + other.Capacity,
                Durability = Durability + other.Durability,
                Flavor = Flavor + other.Flavor,
                Texture = Texture + other.Texture,
                Calories = Calories + other.Calories
            };
        }

        public Ingredient MultiplyBy(int i)
        {
            return new Ingredient
            {
                Capacity = Capacity * i,
                Durability = Durability * i,
                Flavor = Flavor * i,
                Texture = Texture * i,
                Calories = Calories * i,
            };
        }

        public int Score
        {
            get
            {
                if (Capacity <= 0 || Durability <= 0 || Flavor <= 0 || Texture <= 0)
                {
                    return 0;
                }
                return Capacity * Durability * Flavor * Texture;
            }
        }
    }





}

using System;
using System.Linq;

namespace AdventOfCode.Solutions.Year2015
{

    class Day21 : ASolution
    {
        int PlayerHP;
        int BossHP;
        int BossAP;
        int BossDP;

        ShopItem[] weapons;
        ShopItem[] armours;
        ShopItem[] rings;

        public Day21() : base(21, 2015, "RPG Simulator 20XX")
        {
            var arr = Input.SplitByNewline();
            this.PlayerHP = 100;
            this.BossHP = Int32.Parse(arr[0].Split(":")[1].Trim());
            this.BossAP = Int32.Parse(arr[1].Split(":")[1].Trim());
            this.BossDP = Int32.Parse(arr[2].Split(":")[1].Trim());

            //create shop inventory
            weapons = new ShopItem[]
            {
                new ShopItem { Name = "Dagger", Cost = 8, Damage = 4, Armour = 0, Group = "Weapons" },
                new ShopItem { Name = "Shortsword", Cost = 10, Damage = 5, Armour = 0, Group = "Weapons" },
                new ShopItem { Name = "Warhammer", Cost = 25, Damage = 6, Armour = 0, Group = "Weapons" },
                new ShopItem { Name = "Longsword", Cost = 40, Damage = 7, Armour = 0, Group = "Weapons" },
                new ShopItem { Name = "Greataxe", Cost = 74, Damage = 8, Armour = 0, Group = "Weapons" },
            };

            armours = new ShopItem[]
            {
                new ShopItem { Name = "Leather", Cost = 13, Damage = 0, Armour = 1, Group = "Armour" },
                new ShopItem { Name = "Chainmail", Cost = 31, Damage = 0, Armour = 2, Group = "Armour" },
                new ShopItem { Name = "Splintmail", Cost = 53, Damage = 0, Armour = 3, Group = "Armour" },
                new ShopItem { Name = "Bandedmail", Cost = 75, Damage = 0, Armour = 4, Group = "Armour" },
                new ShopItem { Name = "Platemail", Cost = 102, Damage = 0, Armour = 5, Group = "Armour" },
                new ShopItem { Name = "No Armour", Cost = 0, Damage = 0, Armour = 0, Group = "Armour" },
            };

            rings = new ShopItem[]
            {
                new ShopItem { Name = "Damage +1", Cost = 25, Damage = 1, Armour = 0, Group = "Rings" },
                new ShopItem { Name = "Damage +2", Cost = 50, Damage = 2, Armour = 0, Group = "Rings" },
                new ShopItem { Name = "Damage +3", Cost = 100, Damage = 3, Armour = 0, Group = "Rings" },
                new ShopItem { Name = "Defence +1", Cost = 20, Damage = 0, Armour = 1, Group = "Rings" },
                new ShopItem { Name = "Defence +2", Cost = 40, Damage = 0, Armour = 2, Group = "Rings" },
                new ShopItem { Name = "Defence +3", Cost = 80, Damage = 0, Armour = 3, Group = "Rings" },
                new ShopItem { Name = "No Ring 1", Cost = 0, Damage = 0, Armour = 0, Group = "Rings" },
                new ShopItem { Name = "No Ring 2", Cost = 0, Damage = 0, Armour = 0, Group = "Rings" },
            };
        }

        protected override string SolvePartOne()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "91";
            var allPossibleCombinations =
                from w in weapons
                from a in armours
                from ring1 in rings
                from ring2 in rings
                select new
                {
                    Attack = w.Damage + ring1.Damage + ring2.Damage,
                    Defence = a.Armour + ring1.Armour + ring2.Armour,
                    Cost = w.Cost + a.Cost + ring1.Cost + ring2.Cost
                };
            int min = int.MaxValue;
            foreach (var c in allPossibleCombinations)
            {
                if (isPlayerAlive(c.Attack, c.Defence))
                    min = Math.Min(min, c.Cost);
            }

            this.TPart1 = watch.ElapsedMilliseconds.ToString();

            return min.ToString();
        }

        protected override string SolvePartTwo()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //return "158";
            var allPossibleCombinations =
                from w in weapons
                from a in armours
                from ring1 in rings
                from ring2 in rings
                select new
                {
                    Attack = w.Damage + ring1.Damage + ring2.Damage,
                    Defence = a.Armour + ring1.Armour + ring2.Armour,
                    Cost = w.Cost + a.Cost + ring1.Cost + ring2.Cost
                };
            int max = 0;
            foreach (var c in allPossibleCombinations)
            {
                if (!isPlayerAlive(c.Attack, c.Defence))
                    max = Math.Max(max, c.Cost);
            }

            this.TPart2 = watch.ElapsedMilliseconds.ToString();

            return max.ToString();
        }

        private bool isPlayerAlive(int playerAP, int playerDP)
        {
            var turnsToKillBoss = (int)Math.Ceiling(BossHP / (double)(playerAP - BossDP));
            return PlayerHP - (BossAP - playerDP) * (turnsToKillBoss - 1) >= 0;
        }
    }

    public class ShopItem
    {
        public string Name;
        public int Cost;
        public int Damage;
        public int Armour;
        public string Group;
    }
}

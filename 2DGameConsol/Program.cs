using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;

class Program
{
    static void Main(string[] args)
    {
        // ===== TEST 1: Kamp =====
        Creature orc = new Creature { Name = "Orc" };
        Creature knight = new Creature { Name = "Knight" };

        // Orc får et våben
        orc.Loot(new AttackItem
        {
            Name = "Sword",
            Hit = 30,
            Lootable = true
        });

        // Knight får defence
        knight.Loot(new DefenceItem
        {
            Name = "Shield",
            ReduceHitPoint = 5,
            Lootable = true
        });

        Console.WriteLine("KAMP STARTER");
        Console.WriteLine($"Knight HP: {knight.Damage.HitPoints}");
        Console.WriteLine();

        while (!knight.IsDead())
        {
            int damage = orc.Hit();

            Console.WriteLine($"Orc slår med {damage} damage");

            knight.ReceiveHit(damage);

            Console.WriteLine($"Knight HP nu: {knight.Damage.HitPoints}");
            Console.WriteLine();
        }

        Console.WriteLine("Knight er død!");
        Console.WriteLine("KAMP SLUTTER");

        Console.WriteLine();
        Console.WriteLine("===== TEST 2: Decorator =====");

        // ===== TEST 2: Decorator =====
        IAttackComponent sword = new AttackItem { Name = "Sword", Hit = 10 };

        IAttackComponent boostedSword = new DamageBoostDecorator(sword, 5);

        Console.WriteLine($"Boosted damage: {boostedSword.GetHit()}");

        Console.WriteLine();
        Console.WriteLine("===== TEST 3: PatternWorks =====");

        // ===== TEST 3: PatternWorks =====
        PatternWorks pw = new PatternWorks();
        pw.DemoDecorator();

        Console.ReadLine();
    }
}
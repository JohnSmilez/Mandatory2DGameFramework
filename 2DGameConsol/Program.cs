using Mandatory2DGameFramework.Configuration;
using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Typer;
using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== TEST 1: Kamp =====
        Creature orc = new Creature { Name = "Orc" };
        Creature knight = new Creature { Name = "Knight" };

        orc.Loot(new AttackItem { Name = "Sword", Hit = 30, Lootable = true });
        knight.Loot(new DefenceItem { Name = "Shield", ReduceHitPoint = 5, Lootable = true });

        // ===== Observer test setup =====
        var observer = new PatternWorks.ConsoleCreatureObserver();
        knight.AttachObserver(observer);
        orc.AttachObserver(observer); // valgfrit, hvis du vil følge Orcs status

        Console.WriteLine("KAMP STARTER");
        Console.WriteLine($"Knight HP: {knight.Damage.HitPoints}");
        Console.WriteLine();

        while (!knight.IsDead())
        {
            int damage = orc.Hit();
            Console.WriteLine($"Orc slår med {damage} damage");

            // Knight modtager hit – observeren får besked
            knight.ReceiveHit(damage);

            Console.WriteLine($"Knight HP nu: {knight.Damage.HitPoints}");
            Console.WriteLine();
        }

        Console.WriteLine("Knight er død!");
        Console.WriteLine("KAMP SLUTTER");
        Console.WriteLine();

        // ===== TEST 2: Decorator =====

        Console.WriteLine("Tester decorator");
        IAttackComponent sword = new AttackItem { Name = "Sword", Hit = 10 };
        IAttackComponent boostedSword = new DamageBoostDecorator(sword, 5);
        Console.WriteLine($"Boosted damage: {boostedSword.GetHit()}");

        // ===== TEST 3: PatternWorks demo =====
        PatternWorks pw = new PatternWorks(); // vi laver en instans af PatternWorks for at kunne kalde demo-metoderne
        pw.DemoDecorator();

        //===== TEST 4: Operator Overload ===== // ÆNDRER I UGE 15 når han viser sit
        Console.WriteLine();
        Console.WriteLine("===== TEST 5: Operator Overload =====");

        Damage d1 = new Damage(20);
        Damage d2 = new Damage(30);

        // Her bruger vi din overloaded + operator
        
        Damage total = d1 + d2;

        Console.WriteLine($"Damage 1: {d1.HitPoints}");
        Console.WriteLine($"Damage 2: {d2.HitPoints}");
        Console.WriteLine($"Total Damage: {total.HitPoints}");

        // ===== TEST 5: Composite =====
        Console.WriteLine();
        Console.WriteLine("===== TEST 6: Composite ====="); // Composite bruges til at samle flere AttackItems til ét samlet våben, så man kan behandle dem som én enhed.
        pw.DemoComposite();

        // ===== TEST 6: XML Configuration =====
        Console.WriteLine();
        Console.WriteLine("===== TEST Af XML =====");

        ConfigReader config = new ConfigReader();
        config.StartReadConfigFile("C:\\Users\\Harun\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Configuration\\GameConfig.xml");
        Console.WriteLine($"World MaxX: {config.MaxX}");
        Console.WriteLine($"World MaxY: {config.MaxY}");
        Console.WriteLine($"Game Difficulty: {config.Difficulty}");

        Console.ReadLine();
    }
}
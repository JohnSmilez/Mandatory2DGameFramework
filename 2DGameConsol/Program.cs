using Mandatory2DGameFramework.Configuration;
using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Typer;
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // ===== LOGGER SETUP (VIGTIGT TIL KRAV) =====
        MyLogger.Instance.AddListener(new ConsoleTraceListener());
        MyLogger.Instance.Log("Game started");

        // ===== TEST 1: KAMP =====
        Creature orc = new BasicCreature { Name = "Orc" };
        Creature knight = new KnightCreature { Name = "Knight" };

        orc.Loot(new AttackItem { Name = "Sword", Hit = 30, Lootable = true });
        knight.Loot(new DefenceItem { Name = "Shield", ReduceHitPoint = 5, Lootable = true });

        var observer = new PatternWorks.ConsoleCreatureObserver();

        knight.AttachObserver(observer);
        orc.AttachObserver(observer);

        Console.WriteLine("KAMP STARTER");
        Console.WriteLine($"Knight HP: {knight.Damage.HitPoints}\n");

        while (!knight.IsDead())
        {
            int damage = orc.Hit();

            Console.WriteLine($"Orc slår med {damage} damage");

            knight.ReceiveHit(damage);

            Console.WriteLine($"Knight HP nu: {knight.Damage.HitPoints}\n");
        }

        Console.WriteLine("Knight er død!");
        knight.DetachObserver(observer);

        MyLogger.Instance.Log("Knight died");

        // ===== TEST 2: DECORATOR =====
        Console.WriteLine("\n===== DECORATOR =====");

        IAttackComponent sword = new AttackItem { Name = "Sword", Hit = 10 };
        IAttackComponent boostedSword = new DamageBoostDecorator(sword, 5);

        Console.WriteLine($"Boosted damage: {boostedSword.GetHit()}");

        PatternWorks pw = new PatternWorks();
        pw.DemoDecorator();

        // ===== TEST 3: OPERATOR OVERLOAD =====
        Console.WriteLine("\n===== OPERATOR OVERLOAD =====");

        Damage d1 = new Damage(20);
        Damage d2 = new Damage(30);
        Damage total = d1 + d2;

        Console.WriteLine($"Total Damage: {total.HitPoints}");

        // ===== TEST 4: COMPOSITE =====
        Console.WriteLine("\n===== COMPOSITE =====");
        pw.DemoComposite();

        // ===== TEST 5: XML CONFIG =====
        Console.WriteLine("\n===== XML CONFIG =====");

        ConfigReader config = new ConfigReader();
        config.StartReadConfigFile("C:\\Users\\Harun\\Downloads\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\Configuration\\GameConfig.xml");

        Console.WriteLine($"World MaxX: {config.MaxX}");
        Console.WriteLine($"World MaxY: {config.MaxY}");
        Console.WriteLine($"Difficulty: {config.Difficulty}");

        MyLogger.Instance.Log("Game ended");

        Console.ReadLine();
    }
}
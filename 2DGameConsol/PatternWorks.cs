using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Observer;

public class PatternWorks
{
    // ===== DECORATOR =====
    public void DemoDecorator()
    {
        Console.WriteLine("===== Decorator Demo =====");

        IAttackComponent sword = new AttackItem { Name = "Sword", Hit = 10 };
        Console.WriteLine($"Normal: {sword.GetHit()}");

        IAttackComponent boostedSword = new DamageBoostDecorator(sword, 5);
        Console.WriteLine($"Boosted: {boostedSword.GetHit()}");

        IAttackComponent superSword = new DamageBoostDecorator(boostedSword, 5);
        Console.WriteLine($"Super Boosted: {superSword.GetHit()}");
    }

    // ===== OBSERVER =====
    public class ConsoleCreatureObserver : ICreatureObserver
    {
        public void CreatureHit(Creature creature, int damageTaken)
        {
            Console.WriteLine($"[Observer] {creature.Name} blev ramt for {damageTaken} damage!");
            Console.WriteLine($"[Observer] {creature.Name} har nu {creature.Damage.HitPoints} HP tilbage.");
        }

        public void CreatureDied(Creature creature)
        {
            Console.WriteLine($"[Observer] {creature.Name} er død!");
        }
    }

    // ===== COMPOSITE =====
    public void DemoComposite()
    {
        Console.WriteLine("===== Composite Demo =====");

        IAttackComponent dagger = new AttackItem { Name = "Dagger", Hit = 10 };
        IAttackComponent axe = new AttackItem { Name = "Axe", Hit = 15 };

        AttackComposite composite = new AttackComposite();
        composite.Add(dagger);
        composite.Add(axe);

        Console.WriteLine($"Dagger damage: {dagger.GetHit()}");
        Console.WriteLine($"Axe damage: {axe.GetHit()}");

        Console.WriteLine($"Composite total damage: {composite.GetHit()}");
        Console.WriteLine($"Composite total weight: {composite.GetWeight()}");
    }

    // ===== TEMPLATE + STRATEGY + OBSERVER =====
    public void DemoCreatureCombat()
    {
        Console.WriteLine("===== Creature Combat Demo =====");

        // Bruger concrete classes
        Creature orc = new BasicCreature { Name = "Orc" };
        Creature knight = new KnightCreature { Name = "Knight" };

        // Orc får våben (Composite + Strategy)
        orc.Loot(new AttackItem { Name = "Sword", Hit = 20, Lootable = true });

        //  Knight får defence
        knight.Loot(new DefenceItem { Name = "Shield", ReduceHitPoint = 5, Lootable = true });

        // Observer
        var observer = new ConsoleCreatureObserver();
        orc.AttachObserver(observer);
        knight.AttachObserver(observer);

        // Kamp
        int damage = orc.Hit();
        Console.WriteLine($"Orc slår Knight med {damage} damage");

        knight.ReceiveHit(damage);

        Console.WriteLine($"Knight HP efter slag: {knight.Damage.HitPoints}");
    }
}
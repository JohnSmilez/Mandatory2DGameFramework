using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.Observer;

public class PatternWorks
{
    // Dette er en demo for at vise hvordan Decorator pattern fungerer i vores spil
    public void DemoDecorator()
    {
        // 1. Normal attack item
        IAttackComponent sword = new AttackItem { Name = "Sword", Hit = 10 };
        Console.WriteLine($"Normal: {sword.GetHit()}");

        // 2. Med damage boost decorator
        IAttackComponent boostedSword = new DamageBoostDecorator(sword, 5);
        Console.WriteLine($"Boosted: {boostedSword.GetHit()}");

        // 3. Flere decorators ovenpå hinanden
        IAttackComponent superSword = new DamageBoostDecorator(boostedSword, 5);
        Console.WriteLine($"Super Boosted: {superSword.GetHit()}");
    }
    // Dette er en demo for at vise hvordan Observer pattern fungerer i vores spil
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
}
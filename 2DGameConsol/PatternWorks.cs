using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;

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
}
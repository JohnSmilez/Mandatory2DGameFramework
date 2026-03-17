using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.Strategy;

namespace Mandatory2DGameFramework.model.Strategy
{
    public class BasicHitStrategy : IHitStrategy
    {
        public int CalculateHit(Creature creature)
        {
            if (creature.AttackItems.Count == 0)
            {

                return 1;
            }
            return creature.AttackItems.Sum(a => a.GetHit());
        }
    }
}
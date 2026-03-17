using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.Strategy;
using Mandatory2DGameFramework.Strategy;
using Mandatory2DGameFramework.Typer;
using Mandatory2DGameFramework.worlds;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    /// <summary>
    /// Repræsenterer en skabning i spillet.
    /// En creature kan angribe, modtage skade og samle objekter.
    /// </summary>
 
    public class Creature
    {
        public string Name { get; set; }
        public Damage Damage { get; set; }
        public IHitStrategy HitStrategy { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public List <IAttackComponent>   AttackItems { get; set; } // Bruger IAttackcomponent fra vores decorator
        public List <DefenceItem>  DefenceItems { get; set; }

        public Creature()
        {
            Name = string.Empty;
            Damage = new Damage(100);
            HitStrategy = new BasicHitStrategy(); // default strategy

            AttackItems = new List<IAttackComponent>();
            DefenceItems = new List<DefenceItem>();

        }

        public int Hit()
        {
            return HitStrategy.CalculateHit(this); //Brug af strategy pattern for at beregne hit baseret på creature's state
        }

        public void ReceiveHit(int hit)
        {
            int damage= hit;
            int totalDefense = DefenceItems.Sum(d => d.ReduceHitPoint);
            damage -= totalDefense; // Reducer skaden baseret på creature's forsvar
            if (damage < 0)
            {
                damage = 0;
            }
            Damage.TakeDamage(damage);  
        }

        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable) return;

            if (obj is AttackItem attackItem)
                AttackItems.Add(attackItem);
            else if (obj is DefenceItem defenceItem)
                DefenceItems.Add(defenceItem);
        }

        public bool IsDead()
        {
            return Damage.HitPoints <= 0;
        }



        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Damage)}={Damage.ToString()}, {nameof(AttackItems)}={AttackItems}, {nameof(DefenceItems)}={DefenceItems}}}";
        }
    }
}

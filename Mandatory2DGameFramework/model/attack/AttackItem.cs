using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    /// <summary>
    /// Repræsenterer et angrebsvåben, som kan give skade.
    /// </summary>
    public class AttackItem : WorldObject, IAttackComponent

    {
        //public string  Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }

        public AttackItem()
        {
            Name = string.Empty;
            Hit = 0;
            Range = 0;
        }

        public virtual int GetHit()
        {
            return Hit;
        }

        public virtual int GetWeight()
        {
            return 1; // Standard vægt for et attack item, kan ændres i subklasser
        }
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}

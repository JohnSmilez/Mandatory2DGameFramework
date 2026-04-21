using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class KnightCreature : Creature
    {
        protected override int CalculateDamage(int hit)
        {
            return base.CalculateDamage(hit) / 2;
        }
    }
}
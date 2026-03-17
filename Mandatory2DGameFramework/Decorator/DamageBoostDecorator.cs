using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public class DamageBoostDecorator : AttackDecorator
    {
        private int _extraDamage;

        public DamageBoostDecorator(IAttackComponent attackComponent, int extraDamage) : base(attackComponent)
        {
            _extraDamage = extraDamage;
        }

        public override int GetHit()
        {
            return base.GetHit() + _extraDamage;
        }
    }
}
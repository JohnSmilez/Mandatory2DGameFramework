using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public abstract class AttackDecorator : IAttackComponent
    {
        private readonly IAttackComponent _attackComponent;

        public AttackDecorator(IAttackComponent attackComponent)
        {
            _attackComponent = attackComponent;
        }
        public virtual int GetHit()
        {
            return _attackComponent.GetHit();
        }
        public virtual int GetWeight()
        {
            return _attackComponent.GetWeight();
        }


    }
}

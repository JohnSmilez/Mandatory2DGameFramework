using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public abstract class AttackDecorator : IAttackComponent
    {
        private readonly IAttackComponent _Attackcomponent;

        public AttackDecorator(IAttackComponent attackComponent)
        {
            _Attackcomponent = attackComponent;
        }
        public virtual int GetHit()
        {
            return _Attackcomponent.GetHit();
        }


    }
}

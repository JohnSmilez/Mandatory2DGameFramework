using Mandatory2DGameFramework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackComposite : IAttackComponent
    {
        private List<IAttackComponent> _items= new List<IAttackComponent>();

        public void Add(IAttackComponent item)
        {
            _items.Add(item);
        }

        public void Remove(IAttackComponent component)
        {
            _items.Remove(component);
        }
        public int GetHit()
        {
            return _items.Sum(item => item.GetHit());
        }

        public int GetWeight()
        {
            return _items.Sum(item => item.GetWeight());
        }
    }
}

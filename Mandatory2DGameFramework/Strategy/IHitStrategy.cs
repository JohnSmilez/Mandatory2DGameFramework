using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Strategy
{
    /// <summary>
    /// “I” i SOLID: Interface Segregation Principle – klasser skal kun implementere interfaces de bruger.
    /// </summary>
    public interface IHitStrategy
    {
        int CalculateHit(Creature creature);
    }
}

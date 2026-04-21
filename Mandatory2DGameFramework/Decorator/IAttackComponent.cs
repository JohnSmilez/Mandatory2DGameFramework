using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public interface IAttackComponent
    {
        int GetHit();
        int GetWeight(); // Tilføjet for at kunne beregne vægt af attack itemsf
    }
}

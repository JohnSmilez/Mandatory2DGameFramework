using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Observer
{
    public interface ICreatureObserver
    {
        void CreatureHit(Creature creature, int damageTaken);// kaldes når creature bliver ramt og tager skade, giver creature og damageTaken som parametr
        void CreatureDied(Creature creature); //kaldes når creature dør 0 hp




    }
}

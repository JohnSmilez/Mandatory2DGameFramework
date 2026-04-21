using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BasicCreature : Creature
{
    protected override int CalculateDamage(int hit)
    {
        return base.CalculateDamage(hit);
    }
}
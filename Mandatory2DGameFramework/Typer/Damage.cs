using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Typer
{
    /// <summary>
    /// S - Single Responsibility Principle (SRP)
    /// • Klassen har ét ansvar: at håndtere hit points
    /// • Hver metode har ét formål
    /// </summary>
    
    /// /// <summary>
    /// L - Liskov Substitution Principle (LSP)
    /// • Validering sikrer, at alle Damage-objekter opfører sig korrekt
    /// • Objektet er altid i en valid state
    /// </summary>

    /// <summary>
    /// D - Dependency Inversion Principle (DIP)
    /// • Klassen har ingen afhængigheder til andre klasser
    /// • Bruger kun primitives (f.eks. int)
    /// </summary>

    public class Damage
    {
        

        /// <summary>
        /// O - Open/Closed Principle (OCP)
        /// • Lukket for modifikation (f.eks. private setter, validering)
        /// • Åben for udvidelse (kan arves, tilføje events/logging senere)
        /// </summary>
        public int HitPoints { get; private set; } // encapsulation private set to prevent external modification

        public Damage(int hitPoints)
        {
            if (hitPoints < 0)
            {
                throw new ArgumentException("Hit points cannot be negative.");
            }
            HitPoints = hitPoints;
        }

        //Operator overloading for at kunne lægge to Damage objekter sammen
        public static Damage operator +(Damage d1, Damage d2)
        {
            return new Damage(d1.HitPoints + d2.HitPoints);
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Damage cannot be negative.");
            }
            HitPoints -= damage;
            if (HitPoints < 0)
            {
                HitPoints = 0;
            }
        }
    }
    
}

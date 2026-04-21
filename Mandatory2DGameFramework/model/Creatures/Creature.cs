using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.Strategy;
using Mandatory2DGameFramework.Observer;
using Mandatory2DGameFramework.Strategy;
using Mandatory2DGameFramework.Typer;
using Mandatory2DGameFramework.worlds;
using System.Collections.Generic;
using System.Linq;

namespace Mandatory2DGameFramework.model.Creatures
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public Damage Damage { get; set; }
        public IHitStrategy HitStrategy { get; set; } // manual injection

        private List<ICreatureObserver> _observers = new List<ICreatureObserver>();

        public AttackComposite AttackItems { get; set; }
        public int MaxWeight { get; set; } = 50;
        public List<DefenceItem> DefenceItems { get; set; }

        // ================= CONSTRUCTOR =================

        public Creature()
        {
            Name = string.Empty;
            Damage = new Damage(100);
            HitStrategy = new BasicHitStrategy();

            AttackItems = new AttackComposite();
            DefenceItems = new List<DefenceItem>();
        }

        // ================= OBSERVER =================

        public void AttachObserver(ICreatureObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void DetachObserver(ICreatureObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyHit(int damageTaken)
        {
            foreach (var observer in _observers)
                observer.CreatureHit(this, damageTaken);
        }

        private void NotifyDeath()
        {
            foreach (var observer in _observers)
                observer.CreatureDied(this);
        }

        // ================= STRATEGY =================

        public int Hit()
        {
            int hit = HitStrategy.CalculateHit(this);

            MyLogger.Instance.Log($"{Name} attacks with {hit}");

            return hit;
        }

        // ================= TEMPLATE METHOD =================

        public void ReceiveHit(int hit) //template metode
        {
            int damage = CalculateDamage(hit);

            ApplyDamage(damage);
            AfterHit(damage);

            if (IsDead())
                OnDeath();
        }

        protected virtual int CalculateDamage(int hit)
        {
            int totalDefense = DefenceItems?.Sum(d => d.ReduceHitPoint) ?? 0;

            int damage = hit - totalDefense;

            return damage < 0 ? 0 : damage;
        }
        // kaldes i template recieveHit
        protected virtual void ApplyDamage(int damage)
        {
            Damage.TakeDamage(damage);

            MyLogger.Instance.LogDamage($"{Name} takes {damage} damage. HP: {Damage.HitPoints}");
        }

        protected virtual void AfterHit(int damage)
        {
            NotifyHit(damage);
        }

        protected virtual void OnDeath()
        {
            NotifyDeath();

            MyLogger.Instance.LogDeath($"{Name} died");
        }

        // ================= LOOT =================

        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable) return;

            if (obj is IAttackComponent attackItem)
            {
                if (AttackItems.GetWeight() + attackItem.GetWeight() <= MaxWeight)
                {
                    AttackItems.Add(attackItem);

                    MyLogger.Instance.Log($"{Name} picked up weapon: {attackItem}");
                }
            }
            else if (obj is DefenceItem defenceItem)
            {
                DefenceItems.Add(defenceItem);

                MyLogger.Instance.Log($"{Name} picked up defence: {defenceItem.Name}");
            }
        }

        public bool IsDead()
        {
            return Damage.HitPoints <= 0;
        }

        public override string ToString()
        {
            return $"{{Name={Name}, HP={Damage.HitPoints}}}";
        }
    }
}
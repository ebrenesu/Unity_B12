using Assets.Scripts.Combate.Damage;
using UnityEngine;

namespace Assets.Scripts.Combate.Attack.Decorado
{
    public class WoodAttackerDecorator : AttackerDecorator{
        private readonly int _woodDamage;

        public WoodAttackerDecorator(IAttacker attacker, int woodDamage) : base(attacker){
            _woodDamage = woodDamage;
        }

        public override void Attack(IDamageReceiver damageReceiver){
            base.Attack(damageReceiver);
            damageReceiver.ReceiveDamage(_woodDamage, Color.green);
        }
    }
}
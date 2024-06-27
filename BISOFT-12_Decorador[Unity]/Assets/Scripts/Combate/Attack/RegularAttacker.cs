using Assets.Scripts.Combate.Damage;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Combate.Attack
{
    public class RegularAttacker : IAttacker
    {

        private readonly int _damage;
        public RegularAttacker(int damage) { _damage = damage; }

        public void Attack(IDamageReceiver damageReceiver){
            damageReceiver.ReceiveDamage(_damage, Color.white);
        }
    }
}
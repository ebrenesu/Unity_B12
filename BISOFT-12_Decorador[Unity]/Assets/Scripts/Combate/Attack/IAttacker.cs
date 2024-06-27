using Assets.Scripts.Combate.Damage;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Combate.Attack
{
    public interface IAttacker{
        void Attack(IDamageReceiver damageReceiver);
    }
}
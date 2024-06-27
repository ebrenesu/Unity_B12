using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Combate.Damage
{
    public interface IDamageReceiver{
        void ReceiveDamage(int damage, Color color);
    }
}
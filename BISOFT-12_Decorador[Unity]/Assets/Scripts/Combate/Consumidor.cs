using Assets.Scripts.Combate.Attack;
using Assets.Scripts.Combate.Attack.Decorado;
using Assets.Scripts.Combate.Damage;

using UnityEngine;

namespace Assets.Scripts.Combate
{
    public class Consumidor : MonoBehaviour
    {

        [SerializeField] private DamageReceiver _damageReceiver;

        private RegularAttacker _regularAttacker;
        private AttackerDecorator _fireAttacker; 
        private AttackerDecorator _woodAttacker;
        private AttackerDecorator _fireAndWoodAttacker;

        private void Awake(){
            const int damage = 100;
            const int fireDamage = 10;
            const int woodDamage = 13;

            _regularAttacker = new RegularAttacker(damage);                                 //Ataque normal
            _fireAttacker = new FireAttackerDecorator(_regularAttacker, fireDamage);        //Ataque normal + Fuego
            _woodAttacker = new WoodAttackerDecorator(_regularAttacker, woodDamage);        //Ataque normal + Madera
            _fireAndWoodAttacker = new FireAttackerDecorator(_woodAttacker, fireDamage);    //Ataque normal + Madera + Fuego
        }


        private void Update(){
            if (Input.GetKeyUp(KeyCode.F1))
                _regularAttacker.Attack(_damageReceiver);

            else if (Input.GetKeyUp(KeyCode.F2))
                _fireAttacker.Attack(_damageReceiver);

            else if (Input.GetKeyUp(KeyCode.F3))
                _woodAttacker.Attack(_damageReceiver);

            else if (Input.GetKeyUp(KeyCode.F4))
                _fireAndWoodAttacker.Attack(_damageReceiver);

            else if (Input.GetKeyUp(KeyCode.F5))
                _damageReceiver.Clean();

        }
    }
}
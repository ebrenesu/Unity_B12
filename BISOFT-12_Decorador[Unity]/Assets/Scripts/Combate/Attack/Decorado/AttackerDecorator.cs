using Assets.Scripts.Combate.Damage;

namespace Assets.Scripts.Combate.Attack.Decorado
{
    public class AttackerDecorator : IAttacker
    {
        private readonly IAttacker _attacker;

        public AttackerDecorator(IAttacker attacker){
            _attacker = attacker;
        }

        public virtual void Attack(IDamageReceiver damageReceiver){
            //Virtual permite a las clases 'hijas' sobre escribir los metodos. 
            _attacker.Attack(damageReceiver);
        }

    }
}
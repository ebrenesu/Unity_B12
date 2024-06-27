using TMPro;
using UnityEngine;

namespace Assets.Scripts.Combate.Damage {
    public class DamageReceiver : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private TextMeshProUGUI[] _damageText;
        private int _LastTextUsed = 0;

        public void Awake()
        {
            Clean();

        }

        public void ReceiveDamage(int damage, Color color)
        {
            var txtIdx = GetTextIndexToUse();
            _damageText[txtIdx].SetText(damage.ToString());
            _damageText[txtIdx].color = color;
            _LastTextUsed = txtIdx;
        }

        private int GetTextIndexToUse()
        {
            return (_LastTextUsed + 1) % _damageText.Length;
        }

        internal void Clean(){
            foreach (var damageText in _damageText)
                damageText.SetText(string.Empty);
            _LastTextUsed = -1;
        }
    }
}



using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Scripts.Template
{
    public class Utilitario_Template {
        private static System.Random random;

        private static System.Random NuevoRandom() { 
            return new System.Random();
        }
        public static int PotenciaAtaque(){
            random = NuevoRandom();
            return random.Next(1, 20);
        }
        public static bool ObtenerBooleanAleatorio(){
            random = NuevoRandom();
            return random.Next(2) == 0;
        }

        public static int ValorRandom(int pBase, int pTope){
            random = NuevoRandom();
            return random.Next(pBase, pTope);
        }

        public static IEnumerator Esperar(float pTiempo) { 
            yield return new WaitForSeconds(pTiempo); 
        }
    }
}
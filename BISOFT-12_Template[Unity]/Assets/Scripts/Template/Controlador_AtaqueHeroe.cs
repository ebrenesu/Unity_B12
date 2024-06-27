using System;
using UnityEngine;

namespace Assets.Scenes.Scripts.Template
{
    public class Controlador_AtaqueHeroe : MonoBehaviour{
        [SerializeField] private Heroe _Heroe1;
        [SerializeField] private Heroe _Heroe2;
        [SerializeField] private Heroe _Heroe3;

        private void Awake(){
            PoderesPersonaje(_Heroe1);
            PoderesPersonaje(_Heroe2);
            PoderesPersonaje(_Heroe3);

            Debug.Log("---------");
            Do(_Heroe1);


            Debug.Log("---------");
            Do(_Heroe2);

            Debug.Log("---------");
            Do(_Heroe3);

        }

        private static void Do(Heroe pH){
            //Nos suscribimos al evento que envia la clase heroe.
            pH.OnDamageReceived += () => { 
                Debug.Log($"{pH._Nombre} recibe daño"); 
            };

            while (pH.EstaVivo()) {
                pH.Ataque();
                pH.RecibirDanno(Utilitario_Template.PotenciaAtaque());
            }
            pH.RefrescarLog();
            // pH.Destruir();
            Debug.Log("Nuestro heroe no puede mas!");
        }

        private static void PoderesPersonaje(Heroe pH) {
            string[] AtaquesSimples = null;
            string[] AtaquesMaestros = null;
            switch (pH._Nombre) {
                case "Dai":
                    AtaquesSimples = new string[] { "Corte de espada", "Corte de daga de Papnika ", "Ataque Igneo", "Helada", "Tajo de la Tierra", "Tajo del Agua", "Tajo del Aire" };
                    AtaquesMaestros = new string[] { "Boom", "Avan Strash", "Gigaslash" };
                break;

                case "Popp":
                    AtaquesSimples = new string[] { "Zap", "Mega Ataque Igneo", "Ataque Igneo", "Mini Helada", "Rafaga de viento"};
                    AtaquesMaestros = new string[] { "Medroa", " Cinco Megataques ígneos", "Casi Megante" };
                break;
                
                default :
                    AtaquesSimples = new string[] { "Corte", "Contra ataque", "Estocada"};
                    AtaquesMaestros = new string[] { "Tajo de hielo", "Tajo igneo", "Cruz de aura" };
                break;
            }

            pH.AtaquesSimples = AtaquesSimples;
            pH.AtaquesMaestros = AtaquesMaestros;

        }

    }
}
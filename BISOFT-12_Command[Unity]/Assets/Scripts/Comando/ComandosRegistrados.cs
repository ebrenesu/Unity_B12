using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sealed nos dice que la clase no puede ser instanciada
public sealed class ComandosRegistrados {
    public static GameObject _PersonajeSeleccionado { get; internal set; } 
    public static GameObject _PadreObjetos = GameObject.Find("ControladorPersonaje"); //Contendra todos nuestros objetos.
    public static MonoBehaviour _ObjetoMonoBehaviour;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour{
    public static ControladorPuntos Instancia;
    [SerializeField] private float cantidadPuntos;

    public float CantidadPuntos { get => cantidadPuntos; set => cantidadPuntos = value; }

    private void Awake(){
        if (ControladorPuntos.Instancia == null) {
            ControladorPuntos.Instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }else
            Destroy(gameObject);
    }

    public void SumarPuntos(float pPuntos){
        CantidadPuntos += pPuntos;
    }
    public void RestarPuntos(float pPuntos)
    {
        CantidadPuntos -= pPuntos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour{
    private float _Puntos;
    private TextMeshProUGUI _TextMesh;
    void Start(){
        _TextMesh = GetComponent<TextMeshProUGUI>();
        this.ActualizarPuntos(ControladorPuntos.Instancia.CantidadPuntos);
    }

    void Update(){
        _TextMesh.text = "Puntos: " + _Puntos.ToString("0");
    }

    public void ActualizarPuntos(float pPuntaje) {
        _Puntos = pPuntaje;
    }
}

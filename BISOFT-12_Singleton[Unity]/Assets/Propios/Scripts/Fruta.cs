using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour{
    [SerializeField] private Puntaje Puntaje;
    [SerializeField] private float CantidadPuntos;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")) {
            ControladorPuntos.Instancia.SumarPuntos(CantidadPuntos);
            Puntaje.ActualizarPuntos(ControladorPuntos.Instancia.CantidadPuntos);
            Destroy(gameObject);
        }
    }

}

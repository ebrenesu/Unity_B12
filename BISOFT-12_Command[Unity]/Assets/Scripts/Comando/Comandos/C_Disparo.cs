using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Disparo  : IComando{
    private GameObject _Bala;
    private Rigidbody2D _BalaRB;
    private float _BalaFuerza = 100f;
    private float _Distancia;
    private Vector2 _ActorPosicion, _Direccion, _VectorDisparo;
    public Vector2 _PosicionObjetivo;
    void IComando.Ejecutar(GameObject pActor){
        Debug.Log("Actor " + pActor.name + " PEW PEW PEW ");
        _ActorPosicion = pActor.transform.position;
        _VectorDisparo = _PosicionObjetivo - _ActorPosicion;
        _VectorDisparo.Normalize();
        CrearBala();
        //_BalaRB.AddForce(_VectorDisparo * _BalaFuerza);
        Debug.DrawLine(_PosicionObjetivo, _ActorPosicion, Color.green,2);
    }

    private void CrearBala()
    {
        _Bala = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _Bala.gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
        _Bala.gameObject.transform.position = _ActorPosicion + Vector2.up;
        _BalaRB = _Bala.AddComponent<Rigidbody2D>();
        //_BalaRB.mass = 0.5f;

    }
}

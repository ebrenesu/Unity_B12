using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Salto  : IComando{
    private float _Fuerza = 500;
    private bool _Saltando = false;
    void IComando.Ejecutar(GameObject pActor){
        float salto =  _Fuerza;

        if (pActor.transform.position.y < 0.5f && !_Saltando) {
            pActor.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _Fuerza));
            _Saltando = true;
        }else
            _Saltando = false;

    }
}

using UnityEngine;

public class C_Movimiento : IComando
{
    private float _Horizontal;
    private Vector2 _Movimiento;
    private float _Fuerza = 2;
    private bool _HaciaFrente = true;

    public void Ejecutar(GameObject pActor) {

        Debug.Log("Oh no me muevo");
        Girar(pActor);
        
    }

    private void Girar(GameObject pActor)
    {
        Debug.Log("Algo pasa, no giro tampoco");
    }
}

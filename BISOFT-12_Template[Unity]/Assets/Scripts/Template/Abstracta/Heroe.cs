using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Heroe:MonoBehaviour {
    protected int _Vida = 100;
    [SerializeField] public String _Nombre;
    private string[] _AtaquesSimples;
    private string[] _AtaquesMaestros;
    protected String _Log;
    
    public string[] AtaquesMaestros { get => _AtaquesMaestros; set => _AtaquesMaestros = value; }
    public string[] AtaquesSimples { get => _AtaquesSimples; set => _AtaquesSimples = value; }

    public event Action OnDamageReceived;
    public bool Ataque(){
        //Sección "guionizada" de los metodos abstractos para que actuen los hijos.
        if (PuedeAtacar())
            HacerAtaque();

        return EstaVivo();
    }
    public void RecibirDanno(int damage){
        var isDead = AplicarDanno(damage);
        DannoRecibido(isDead);
        NotificarDannoRecibido();
    }
    private bool AplicarDanno(int damage){
        _Vida -= damage;
        //_Log +="(Vida: " + _Vida+")\n";
        return EstaVivo();
    }
    public bool EstaVivo() {
        if (_Vida <= 0){
            _Vida = 0; 
            return false;
        }else
            return true;
    }
    private void NotificarDannoRecibido(){
        OnDamageReceived?.Invoke();
    }
    public void Destruir() {
        GameObject objetoAEliminar = GameObject.Find(_Nombre);
        if (objetoAEliminar != null)
            Destroy(objetoAEliminar); // Destruye el objeto
        
    }
    private void AddToLog(String pTexto, bool pCambio = false) {
        GameObject obj = GameObject.Find(_Nombre);
        Text logText = obj.GetComponentInChildren<Text>();
        if(pCambio)
            logText.text += pTexto;
        else
            logText.text = pTexto;
    }
    public void RefrescarLog() {
        AddToLog("Nuestro heroe: " + _Nombre + " lucho arduamente:\n" + _Log);
    }

    //Funciones abstractas que los hijos deben de implementar
    protected abstract bool PuedeAtacar();
    protected abstract void HacerAtaque();
    protected abstract void DannoRecibido(bool estaMuerto);
}

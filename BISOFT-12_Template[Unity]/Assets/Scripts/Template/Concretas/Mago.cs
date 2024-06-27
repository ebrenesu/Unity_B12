using Assets.Scenes.Scripts.Template;
using UnityEngine;

public class Mago : Heroe
{
    private int _Cansado = 20;
    protected override void DannoRecibido(bool estaMuerto)
    {
        Debug.Log("Auch, pero todo bien");
        this._Log += " Auch, pero todo bien...\n";
        if (estaMuerto)
            if (Utilitario_Template.ObtenerBooleanAleatorio()) {
                this._Log += "Mini autocuracion +50pts\n";
                Debug.Log("Mini autocuracion +50pts");
                this._Vida = 50;
            }else
                Debug.Log("Maestro, he fallado");
        
    }
    protected override void HacerAtaque(){
        string ataqueLocal = "";
        if (_Vida >= _Cansado)
            ataqueLocal = AtaquesSimples[Utilitario_Template.ValorRandom(0, AtaquesSimples.Length - 1)];
        else
            ataqueLocal = AtaquesMaestros[Utilitario_Template.ValorRandom(0, AtaquesMaestros.Length - 1)];
        this._Log += ataqueLocal+" \n";
        Debug.Log(ataqueLocal);
    }
    protected override bool PuedeAtacar(){
        if (_Vida >= _Cansado)
            return true;
        else
        {
            this._Log += "Estoy muy débil, pero...\n";
            Debug.Log("Estoy muy débil, pero...");
            return Utilitario_Template.ObtenerBooleanAleatorio();
        }

    }
}

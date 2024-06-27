using Assets.Scenes.Scripts.Template;
using UnityEngine;

public class Paladin : Heroe{
    private int _Cansado = 15;
    private int _cantPosima = 3;
    protected override void DannoRecibido(bool estaMuerto){
        Debug.Log("Es lo mejor que tienes!");
        this._Log += "Es lo mejor que tienes!\n";
        if (estaMuerto)
            if (_cantPosima > 0) {
                this._Log += "Botella de vida +50 \n";
                this._Vida = 50;
                _cantPosima--;
            }
            else {
                this._Log += "Ahhhhhhh\n";
                Debug.Log("Ahhhhhhh");
            }
                
    }
    protected override void HacerAtaque(){
        string ataqueLocal = "";
        if (_Vida >= _Cansado)
            ataqueLocal = AtaquesSimples[Utilitario_Template.ValorRandom(0, AtaquesSimples.Length - 1)];
        else
            ataqueLocal = AtaquesMaestros[Utilitario_Template.ValorRandom(0, AtaquesMaestros.Length- 1)];
        this._Log += ataqueLocal + " \n";
        Debug.Log(ataqueLocal);
    }
    protected override bool PuedeAtacar(){
        if (_Vida >= _Cansado)
            return true;
        else {
            this._Log += "No me dare por vencido...\n";
            Debug.Log("No me dare por vencido...");
            return Utilitario_Template.ObtenerBooleanAleatorio();
        }
        
    }
}

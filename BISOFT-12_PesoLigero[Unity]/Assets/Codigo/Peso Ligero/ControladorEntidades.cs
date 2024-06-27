using UnityEngine;

public class ControladorEntidades : MonoBehaviour
{

    int _contador = 0;
    int _tope = 10;
    public GameObject[] _backpacks;
    public Canvas _Canva;
    GameObject[] _NuevosObjetos;

    void Start(){
        while (_contador < _tope) {
             GenerarObjeto();
            //GenerarObjetoClone();
            _contador++;
        }
    }
    
    private void GenerarObjeto() {
        int mId = Random.Range(0, _backpacks.Length);
        GameObject instantiatedObject = Instantiate(_backpacks[mId],_Canva.transform);
        instantiatedObject.transform.localPosition = PosicionNueva();
        instantiatedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        //return instantiatedObject;
    }
    /*
    private void GenerarObjetoClone(){
        int mId = Random.Range(0, _backpacks.Length);
        Backpack objTem = (Backpack)_backpacks[mId];
        GameObject instantiatedObject = _backpacks[mId].Clonar();

        instantiatedObject.transform.localPosition = PosicionNueva();
        instantiatedObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    */
    private Vector3 PosicionNueva() { 
        return new Vector3(Random.Range(-300, 300), Random.Range(-110, 100), 0f);

    }


}

//Estado Intrínseco (elementos que se puedan compartir o son comunes) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Backpack Intrinseco", menuName = "ScriptableObjects/Crear Backpack", order = 1)]
public class Backpack_intr : ScriptableObject{
    // Start is called before the first frame update
    [SerializeField] Sprite _Sprite;
    [SerializeField] string _Nombre;
    [SerializeField] string _Descripcion;

    public Sprite Sprite => _Sprite;
    public string Nombre => _Nombre;
    public string Descripcion => _Descripcion;
}

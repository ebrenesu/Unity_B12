using System;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour{
    public Backpack_intr Intrinseco;
    public int Capacidad;

    private Image _spriteImage;
    private Text _nombreTxt;
    private Text _DescripcionTxt;

    private void Awake(){
        _spriteImage = transform.Find("Image").GetComponent<Image>();
        _nombreTxt = transform.Find("NameText").GetComponent<Text>();
        _DescripcionTxt = transform.Find("DescriptionText").GetComponent<Text>();

        _spriteImage.sprite = Intrinseco.Sprite;
        _nombreTxt.text = Intrinseco.Nombre;
        _DescripcionTxt.text = Intrinseco.Descripcion;
    }

    public Backpack Clonar() {
        GameObject clonedObject = Instantiate(gameObject, transform.parent);
        Backpack clonedBackpack = clonedObject.GetComponent<Backpack>();

        clonedBackpack.Intrinseco = Intrinseco;
        clonedBackpack.Capacidad = Capacidad;

        return clonedBackpack;
    }
    public Backpack Clonar(Transform pTrans)    {
        GameObject clonedObject = Instantiate(gameObject, pTrans);
        Backpack clonedBackpack = clonedObject.GetComponent<Backpack>();

        clonedBackpack.Intrinseco = Intrinseco;
        clonedBackpack.Capacidad = Capacidad;

        return clonedBackpack;
    }

}

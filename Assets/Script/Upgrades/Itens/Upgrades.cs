using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public bool jaUsou;
    public Button botao;
    public Action<Upgrades, bool> OnClick;
    public Image image;
    public Sprite bestiarioImage;
    public Item item;

    public void Clicking()
    {
        OnClick?.Invoke(this,jaUsou);
    }


}

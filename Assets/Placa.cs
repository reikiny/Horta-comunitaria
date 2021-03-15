using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Placa : MonoBehaviour
{
    public NomeDaPlanta nomePlanta;
    public TipoDePlanta tipo;
    public Image Image;
    public Sprite placaSemNada;
    public Action<NomeDaPlanta,Sprite,TipoDePlanta> algo;
    

    private void Start()
    {
        algo += MudarPlaca;
        StartCoroutine(SlowUpdate());
    }
    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            MudarSprite();
        }
    }
    void MudarPlaca(NomeDaPlanta nomeDaPlanta,Sprite sprite,TipoDePlanta tipoDePlanta)
    {
        nomePlanta = nomeDaPlanta;
        tipo = tipoDePlanta;
        Image.sprite = sprite;
    }

    void MudarSprite()
    {
        switch (nomePlanta)
        {
            case NomeDaPlanta.ALFACE:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.REPOLHO:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.TOMATE:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.BATATADOCE:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.CENOURA:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.MANDIOCA:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.BANANA:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.MAMAO:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.LIMAO:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.PANC:
                Image.sprite = Image.sprite;
                break;
            case NomeDaPlanta.Nada:
                Image.sprite = placaSemNada;
                Image.sprite = Image.sprite;
                break;

        }
    }
}

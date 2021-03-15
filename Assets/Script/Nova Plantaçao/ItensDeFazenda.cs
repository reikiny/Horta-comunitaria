using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TipoDeFerramenta
{
    TERRA,
    ANCINHO,
    ADUBAR,
    PLANTAR,
    Plantado

}
public class ItensDeFazenda : MonoBehaviour
{
    public static bool podeContinuar = false;
    

    public TipoDeFerramenta itens;
    public Action<TipoDeFerramenta> click;

    public Sprite terraSprite;
    public Sprite terraArada;
    public Sprite terraAdubada;
    public Sprite terraSeca;
    public Sprite terraAdubada2;

    public Fazendeiro fazendeiro;

    //public Action<int> anima;
    public bool controle;

    private void Start()
    {
        gameObject.SetActive(false);    
    }

    //o controle simplemente mostra se voce clicou ou nao, e dentro do evento click vc passa qual tipo de ferramenta pra TERRA
    public void Ancinho()
    {
        if (!controle)
        {
            //anima(2, true);
           // itens = TipoDeFerramenta.ANCINHO;
            //podeContinuar = true;
            click?.Invoke(TipoDeFerramenta.ANCINHO);
            controle = true;
            //clickou = true;
        }
    }
    public void Adubar()
    {
        if (!controle)
        {
            //anima(1, true);
           // itens = TipoDeFerramenta.ADUBAR;
            //podeContinuar = true;
            click?.Invoke(TipoDeFerramenta.ADUBAR);
            controle = true;
            //clickou = true;
        }
    }

    public void Plantar()
    {
        if (!controle)
        {
           // itens = TipoDeFerramenta.PLANTAR;
            //podeContinuar = true;
            click?.Invoke(TipoDeFerramenta.PLANTAR);
            controle = true;
            //clickou = true;
        }
    }


}

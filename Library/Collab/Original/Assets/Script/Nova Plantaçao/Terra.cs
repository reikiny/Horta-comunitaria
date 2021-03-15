using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum EstadosDaTerra { SOIL, ARADO, ADUBADO, PLANTAR, REGAR, PODECOLER }
public class Terra : MonoBehaviour
{
    public EstadosDaTerra estadosDaTerra;
    public SpriteRenderer sprite;
    public ItensDeFazenda itensDeFazenda;   
    public Vida vida;
    public Fazendeiro fazendeiro;
    public UnityEvent botao;
    public SpriteRenderer[] spriteMulti;


    public Action<float, float> algo;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        itensDeFazenda.click += ClicouNaTerra;
        fazendeiro.OnEndAction += MudarEstadoDaTerra;
    }


    private void OnMouseUpAsButton()
    {
        if (!ItensDeFazenda.podeContinuar)
        {
            botao.Invoke();
        }
    }
    void ClicouNaTerra()
    {
        
        algo?.Invoke(transform.position.x, transform.position.y);
    }

    void MudarEstadoDaTerra()
    {
       
        if (itensDeFazenda.itens == TipoDeFerramenta.ANCINHO && estadosDaTerra == EstadosDaTerra.SOIL)
        {            
            sprite.sprite = itensDeFazenda.terraArada;
            for (int i = 0; i < spriteMulti.Length; i++)
            {
                spriteMulti[i].sprite = itensDeFazenda.terraArada;
            }
            estadosDaTerra = EstadosDaTerra.ARADO;
        }
        if (itensDeFazenda.itens == TipoDeFerramenta.ADUBAR && estadosDaTerra == EstadosDaTerra.ARADO)
        {
            sprite.sprite = itensDeFazenda.terraAdubada;
            estadosDaTerra = EstadosDaTerra.ADUBADO;
        }
        if (estadosDaTerra == EstadosDaTerra.SOIL)
        {
            sprite.sprite = itensDeFazenda.terraSprite;
            for (int i = 0; i < spriteMulti.Length; i++)
            {
                spriteMulti[i].sprite = itensDeFazenda.terraSprite;
            }
        }
    }

}


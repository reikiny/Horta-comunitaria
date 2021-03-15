using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plantar : MonoBehaviour
{
   
    private bool vaiColer;
    int pontosTotais;
    float tempo;
    public Combo combo;
    public Terra terra;
    public ItensDeFazenda itensDeFazenda;
    public Vida vida;
    public Agua agua;
    public ItemDisplay[] itensDisplay;
    
    public int pontoSoil;
    public int pontoAdubado;

    private Item plantaEscolhida;
    private int quantidadePlantada;
    public Player player;

    public Image image;
    private void Start()
    {
        for (int i = 0; i < itensDisplay.Length; i++)
        {
            itensDisplay[i].OnPlantar += Plantando;
        }
        terra.fazendeiro.OnEndAction += Colher;
        terra.fazendeiro.OnEndAction += Planta;
    }
    private void Update()
    {
        EsperaNascer();

    }
    public void Plantando(Item item, int quantidade)
    {
        agua.setAgua(item.aguaConsumida);
        vida.setHealth(item.vidaConsumida);
        plantaEscolhida = item;
        quantidadePlantada = quantidade;
        player.OnPlantar?.Invoke(item.nomeDaPlanta, quantidade);
        player.quest?.CheckGoals();
        combo.tipoDaPlanta = item.tipoDaPlanta;
    }
    public void Planta()
    {
        if (plantaEscolhida != null) { 
            if (itensDeFazenda.itens == TipoDeFerramenta.PLANTAR)
            {
            if (terra.estadosDaTerra == EstadosDaTerra.SOIL)
                {
                    pontosTotais = plantaEscolhida.ponto - pontoSoil;
                }
                if (terra.estadosDaTerra == EstadosDaTerra.ARADO)
                {
                    pontosTotais = plantaEscolhida.ponto;
                }
                if (terra.estadosDaTerra == EstadosDaTerra.ADUBADO)
                {
                    pontosTotais = plantaEscolhida.ponto + pontoAdubado;
                }
                terra.sprite.sprite = plantaEscolhida.plantarSprite;

                for (int i = 0; i < terra.spriteMulti.Length; i++)
                {
                    if(i + 2 <= quantidadePlantada)
                        terra.spriteMulti[i].sprite = plantaEscolhida.plantarSprite;
                }

                tempo = plantaEscolhida.tempoParaCrescer;
                terra.estadosDaTerra = EstadosDaTerra.PLANTAR;
                vaiColer = true;
            }

        }
    }

    void EsperaNascer()
    {
        if (plantaEscolhida != null)
        {
            if (tempo <= 0 && terra.estadosDaTerra == EstadosDaTerra.PLANTAR)
            {
                terra.sprite.sprite = plantaEscolhida.crescidaSprite;

                for (int i = 0; i < terra.spriteMulti.Length; i++)
                {
                    if (i + 2 <= quantidadePlantada)
                        terra.spriteMulti[i].sprite = plantaEscolhida.crescidaSprite;
                }

                tempo = plantaEscolhida.tempoParaCrescer;
                terra.estadosDaTerra = EstadosDaTerra.PODECOLER;
                vaiColer = false;
                itensDeFazenda.click?.Invoke();
                ItensDeFazenda.podeContinuar = true;
            }
            else if (vaiColer)
            {
                image.fillAmount = tempo/plantaEscolhida.tempoParaCrescer;
                tempo -= Time.deltaTime;
            }
        }
    }
    void Colher()
    {
        if (!ItensDeFazenda.podeContinuar && terra.estadosDaTerra == EstadosDaTerra.PODECOLER)
        {
            player.OnColherItens?.Invoke(plantaEscolhida.nomeDaPlanta, quantidadePlantada);
            plantaEscolhida = null;
            player.OnColherPontos?.Invoke(pontosTotais);
            player.quest?.CheckGoals();           
            Pontos.scoreNumber += pontosTotais;
            pontosTotais = 0;
            terra.estadosDaTerra = EstadosDaTerra.SOIL;
            itensDeFazenda.itens = TipoDeFerramenta.TERRA;
        }

    }
    //aaaaa
}

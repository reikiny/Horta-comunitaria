using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public enum EstadosDaTerra { SOIL, ARADO, ADUBADO, PLANTAR, REGAR, PODECOLER }
public class Terra : MonoBehaviour
{
 
    public EstadosDaTerra estadosDaTerra;
    public Image sprite;
    public ItensDeFazenda itensDeFazenda;
    public Vida vida;
    public Fazendeiro fazendeiro;
    public UnityEvent botao;
    public Image[] spriteMulti;
    public bool clickou;
    private TipoDeFerramenta tipo;
    public Action<float, float> algo;
    public int index;

    public Material tub;
    public Material veg;
    public Material frut;
    public ParticleSystem colherParticula;

    public bool adubo;
    private void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        //
        Vector3 vetor = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 5), (Screen.height / 4)-20f, 90));
        transform.position = new Vector3(transform.position.x, vetor.y, transform.position.z);
        itensDeFazenda.click += ClicouNaTerra;
        fazendeiro.OnEndAction += MudarEstadoDaTerra;
       
    }
    private void OnEnable()
    {
        StartCoroutine(SlowUpdate());
    }
    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            //SEGUNDO: se clicou e o fazendeiro nao tiver ocupado ele faz a ação que deveria fazer
 
            if (clickou)
            {
                if (!fazendeiro.ocupado && index == fazendeiro.sequencia[0])
                {
                    itensDeFazenda.itens = tipo;
                    if (tipo == TipoDeFerramenta.ADUBAR)
                    {
                        //animação de adubar
                        fazendeiro.anima?.Invoke(1);
                        adubo = true;
                    }
                    if (tipo == TipoDeFerramenta.ANCINHO)
                    {
                        //animação de arar
                        fazendeiro.anima?.Invoke(2);
                    }
                    if (tipo == TipoDeFerramenta.PLANTAR)
                    {
                        //animação de plantar
                        fazendeiro.anima?.Invoke(3);

                    }
                    if(tipo == TipoDeFerramenta.Plantado)
                    {
                        //animação de colher 
                        fazendeiro.anima?.Invoke(4);
                        colherParticula.Play();
                    }
                    ItensDeFazenda.podeContinuar = true;
                    algo?.Invoke(transform.position.x, transform.position.y + 1f);
                    clickou = false;
                }

            }

            //coloquei aqui pq estava bugando pra voltar pro soil pq nao tinha prioridade em qual executa primeiro
            if (estadosDaTerra == EstadosDaTerra.SOIL)
            {
                if(vida.estadosDaVida == EstadosDaVida.VidaCritica)
                {
                    sprite.sprite = itensDeFazenda.terraSeca;
                    //for (int i = 0; i < spriteMulti.Length; i++)
                    //{
                    //    spriteMulti[i].sprite = itensDeFazenda.terraSeca;
                    //}
                }
                else
                {
                    sprite.sprite = itensDeFazenda.terraSprite;
                    //for (int i = 0; i < spriteMulti.Length; i++)
                    //{
                    //    spriteMulti[i].sprite = itensDeFazenda.terraSprite;
                    //}
                }
                
            }
        }
    }
    //private void OnMouseUpAsButton()
    //{
    //    //coloquei o controle pra ele poder clicar dnovo
    //    if (!itensDeFazenda.controle)
    //    {
    //        botao.Invoke();
    //    }
    //}
    public void ClickBotao()
    {
        if (!itensDeFazenda.controle)
        {
            botao.Invoke();
        }
    }

    void ClicouNaTerra(TipoDeFerramenta ferType)
    {
        //PRIMEIRO: pega o tipo da ferramenta e avisa que clicou 
        tipo = ferType;
        clickou = true;
        fazendeiro.sequencia.Add(index);
    }
 
    void MudarEstadoDaTerra()
    {
       
        if (itensDeFazenda.itens == TipoDeFerramenta.ANCINHO && estadosDaTerra == EstadosDaTerra.SOIL)
        {            
            sprite.sprite = itensDeFazenda.terraArada;
            //for (int i = 0; i < spriteMulti.Length; i++)
            //{
            //    spriteMulti[i].sprite = itensDeFazenda.terraArada;
            //}
            estadosDaTerra = EstadosDaTerra.ARADO;
        }
        if (itensDeFazenda.itens == TipoDeFerramenta.ADUBAR && estadosDaTerra == EstadosDaTerra.ARADO)
        {
            sprite.sprite = itensDeFazenda.terraAdubada;
            estadosDaTerra = EstadosDaTerra.ADUBADO;

        }
        if (itensDeFazenda.itens == TipoDeFerramenta.ADUBAR && estadosDaTerra == EstadosDaTerra.SOIL || itensDeFazenda.itens == TipoDeFerramenta.ANCINHO && estadosDaTerra == EstadosDaTerra.ADUBADO)
        {
            sprite.sprite = itensDeFazenda.terraAdubada2;
            estadosDaTerra = EstadosDaTerra.ADUBADO;

        }

    }

    public void QuantidadeEmitida(TipoDePlanta tipo, int vidaAoPlantar)
    {
        var emission = colherParticula.emission;

        if (vidaAoPlantar >= 7)
        {
            emission.rateOverTime = 20;
        }
        if (vidaAoPlantar == 4 || vidaAoPlantar == 5 || vidaAoPlantar == 6)
        {
            emission.rateOverTime = 10;
        }
        if (vidaAoPlantar == 1 || vidaAoPlantar == 2 || vidaAoPlantar == 3)
        {
            emission.rateOverTime = 3;
        }

        if (tipo == TipoDePlanta.Frutiferas)
            colherParticula.GetComponent<ParticleSystemRenderer>().material = frut;

        if (tipo == TipoDePlanta.Vegetais)
            colherParticula.GetComponent<ParticleSystemRenderer>().material = veg;

        if (tipo == TipoDePlanta.Tuberculos)
            colherParticula.GetComponent<ParticleSystemRenderer>().material = tub;

    }

}


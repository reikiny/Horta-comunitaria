using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Fazendeiro : MonoBehaviour
{
    private Animator myAnimacion;
   
    private Terra[] terra;
    public Slider slider;
    public Transform voltaPosicion;
    public float tempoParaFazer;
    public static float tempo;
    public ItensDeFazenda[] itensDeFazenda;
   

    public Action OnEndAction;
    public Action<int> anima;

    public bool ocupado = false;
    public List<int> sequencia;
    public AudioSource source;
    public AudioClip arar;
    public AudioClip adubar;
    public AudioClip regar;
    public AudioClip bater;
    private void Start()
    {
        slider.gameObject.SetActive(false);
        anima += EstadosDaAnimacao;
        transform.position = new Vector2(voltaPosicion.position.x, voltaPosicion.position.y);
        terra = FindObjectsOfType<Terra>();
        myAnimacion = GetComponent<Animator>();
        for (int i = 0; i < terra.Length; i++)
        {
            terra[i].algo += MudarPosicao;
        }
       
    }
    private void Update()
    {
        FazerTarefas();
        slider.transform.position = new Vector2(transform.position.x + 1f, transform.position.y);

        
    }

    public void EstadosDaAnimacao(int animacao)
    {
        if (animacao == 0)
        {
            myAnimacion.SetBool("Abubar", false);
            myAnimacion.SetBool("Arar", false);
            myAnimacion.SetBool("Plantar", false);
            myAnimacion.SetBool("Coletar", false);
        }
        if(animacao == 1)
        {
            source.Pause();
            source.PlayOneShot(adubar);
            myAnimacion.SetBool("Abubar",true);
            
        }
        if (animacao == 2)
        {
            source.Pause();
            source.PlayOneShot(arar);
            myAnimacion.SetBool("Arar", true);
           
        }
        if (animacao == 3)
        {
           
            myAnimacion.SetBool("Plantar", true);
            
        }
        if (animacao == 4)
        {
            
            myAnimacion.SetBool("Coletar", true);

        }
    }
    public void AnimacaoDaPlantacao(String algo)
    {
        myAnimacion.SetTrigger(algo);
    }
   public void MudarPosicao(float xPo,float yPo)
    {   
        transform.position = new Vector2(xPo,yPo);
        slider.gameObject.SetActive(true);
    }

    public void FazerTarefas()
    {
        slider.maxValue = tempoParaFazer;
        slider.value = tempo;

        if (tempo > tempoParaFazer)
        {
            tempo = 0;
            ItensDeFazenda.podeContinuar = false;
            OnEndAction?.Invoke();
            sequencia.RemoveAt(0);
            for (int i = 0; i < itensDeFazenda.Length; i++)
            {
                //se ele tiver clicado na terra pra arar ou adubar o controle fica falso pra ele poder clicar denovo e plantar, se nao o controle só fica falso quando ele colhe, assim ele nao consegue clicar enquanto ta plantando
                if (itensDeFazenda[i].itens == TipoDeFerramenta.ADUBAR || itensDeFazenda[i].itens == TipoDeFerramenta.ANCINHO)
                {
                    itensDeFazenda[i].controle = false;

                }
            }
            
            transform.position = new Vector2(voltaPosicion.position.x, voltaPosicion.position.y);
            EstadosDaAnimacao(0);
            ocupado = false;
            slider.gameObject.SetActive(false);
        }
        else if (ItensDeFazenda.podeContinuar)
        {
            tempo += Time.deltaTime;
            ocupado = true;
        }
    }

   public void SomApalpar()
    {
        source.Pause();
        source.PlayOneShot(bater);
    }

    public void SomRegar()
    {
        source.Pause();
        source.PlayOneShot(regar);
    }


}

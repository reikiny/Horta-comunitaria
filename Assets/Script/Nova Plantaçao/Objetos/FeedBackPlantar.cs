using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedBackPlantar : MonoBehaviour
{
    public Plantar plantar;
    public Image[] sprites;
    public Image slideVida;
    public int ativo;
    public GameObject panel;
    public float tem;
    public Sprite semente;
    public Sprite metade;
    public Sprite crescida;
    void Start()
    {
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            plantar.itensDisplay[i].OnFeedBack += OnFeedBackON;
            plantar.itensDisplay[i].OnPlantar += OnConfirm;
           // plantar.player.OnPlantar += SAIR;
        }
        ativo= -1;
    }

    public void MudarSprite()
    {
        //print(plantar.tempo + " CA: " + (float)tem / 3);
        if (plantar.tempo > (float)(tem / 3) * 2)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sprite=semente;

            }
        }
        else if (plantar.tempo < (float)(tem / 3) * 2 && plantar.tempo > (float)(tem / 3))
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sprite = metade;

            }
        }
        else
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sprite=crescida;

            }
        }
    }

    void OnFeedBackON()
    {
        //desativa o ultimo que foi ativado
        if (ativo >= 0)
        {
            plantar.itensDisplay[ativo].preview = false;
            ativo = -1;
        }
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            if (plantar.itensDisplay[i].preview)
            {
                ativo = i;
            }
            if (i != ativo)
            {
                //reseta os outrs
                plantar.itensDisplay[i].amount = plantar.itensDisplay[i].item.quantidadePossuida;
                plantar.itensDisplay[i].Desatb();
            }

        }
        //Set sprites
        for (int i = 0; i < sprites.Length; i++)
        {
            if (plantar.itensDisplay[ativo].amount == 0)
            {
                if (i + 1 <= plantar.itensDisplay[ativo].item.quantidadePossuida)
                {
                    sprites[i].sprite = plantar.itensDisplay[ativo].item.plantarSprite;
                    sprites[i].gameObject.SetActive(true);
                }
                else sprites[i].gameObject.SetActive(false);
            }
            else
            {
                sprites[i].sprite = plantar.itensDisplay[ativo].item.plantarSprite;
                sprites[i].gameObject.SetActive(true);
            }

        }
        semente = plantar.itensDisplay[ativo].item.plantarSprite;
        metade = plantar.itensDisplay[ativo].item.mudaSprite;
        crescida = plantar.itensDisplay[ativo].item.crescidaSprite;

        //set slides
        slideVida.gameObject.SetActive(true);
        slideVida.fillAmount = (float)(plantar.itensDisplay[ativo].vida.maxHealth-plantar.itensDisplay[ativo].item.vidaConsumida)/(float)plantar.itensDisplay[ativo].vida.maxHealth;
       

    }
   
    //Usar isso no painel pra fechar o inventario.
    public void CLOSE()
    {
        ResetaFeedback();
        Desativar();
       
    }

    //Usar quando terminar a plantação
    public void Desativar()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            Color color = sprites[i].color;
            color.a = 0.5f;
            sprites[i].color = color;
            sprites[i].gameObject.SetActive(false);
        }
    }

    //Usar no Plantar.TESTE()
    public void ResetaFeedback()
    {
        if (ativo >= 0)
        {
            plantar.itensDisplay[ativo].Desatb();
            ativo = -1;
        }

        slideVida.gameObject.SetActive(false);
        panel.SetActive(false);
    }

    //Desativa os feedbacks
    void OnConfirm(Item item, int quantidade)
    {
        plantar.itensDeFazenda.Plantar();
        
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public enum PlantImag { SEMENTE, PLANTADA, CRESCIDA, BLOQUEADA, LOJA, BLOQUEADALOJA };
public class ItemDisplay : MonoBehaviour
{
    public PlantImag plantImag;
    public Text quantia;
    public Item item;
   
    public Action<Item, int> OnPlantar;
    public Action OnFeedBack;
    public Vida vida;
    
    public bool preview;
    public int amount;
    public GameObject fundoTexto;


    private Image image;
    private Button botao;


    private void Start()
    {

        image = GetComponent<Image>();
        botao = GetComponent<Button>();
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
            if (plantImag == PlantImag.SEMENTE)
            {
                image.sprite = item.sprite;
            }
            else if (plantImag == PlantImag.BLOQUEADA)
            {
                image.sprite = item.lockSprite;
            }


            if (item.liberada)
            {
                plantImag = PlantImag.SEMENTE;
                if (preview)
                    quantia.text = amount.ToString();
                else
                    quantia.text = item.quantidadePossuida.ToString();
                BotaoOn();
                fundoTexto.SetActive(true);
            }
            else
            {
                fundoTexto.SetActive(false);
                plantImag = PlantImag.BLOQUEADA;
                botao.interactable = false;
                quantia.text = null;
            }
        }
    }

    public void BotaoOn()
    {
        if (item.quantidadePossuida > 0 && item.vidaConsumida - vida.currentHealth < 0)
        {
            botao.interactable = true;
        }
        else
        {
            botao.interactable = false;
        }

    }
    
    public void EscolherPlanta()
    {
        if (item.quantidadePossuida <= 4)
        {
            OnPlantar?.Invoke(item, item.quantidadePossuida);
            item.quantidadePossuida = 0;
        }
        else
        {
            OnPlantar?.Invoke(item, 4);
            item.quantidadePossuida -= 4;
        }      
    }

    public void TESTE()
    {
        if (item.liberada)
        {

            preview = !preview;
            if (preview == true)
            {
                amount = item.quantidadePossuida;
                if (amount <= 4)
                    amount = 0;
                else
                    amount -= 4;

                OnFeedBack?.Invoke();
            }
            else
            {
                EscolherPlanta();
                Desatb();
                transform.parent.parent.parent.parent.gameObject.SetActive(false);
            }
        }  
    }

    
    public void Desatb()
    {
        preview = false;
        amount = item.quantidadePossuida;
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {            
            EventSystem.current.SetSelectedGameObject(null);  
        }
    }
}


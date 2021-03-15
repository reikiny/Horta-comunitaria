using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojaDisplay : MonoBehaviour
{
    public Text nome;
    public Text preço;
    public Image image;
    public Item planta;
    public Adubo adubo;
    public CenarioItem cenarioItem;
    private Button botao;
    public Sprite spriteFundo;
    private Image fundoImg;
    private void OnEnable()
    {
        fundoImg = GetComponent<Image>();
        botao = GetComponent<Button>();
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            if(planta != null)
            {
                if (planta.liberada)
                {
                    // nome.text = planta.nomeDaPlanta.ToString();
                    Color color = image.color;
                    color.a = 1f;
                    image.color = color;

                    preço.text = planta.preco.ToString();
                    image.sprite = planta.sprite;
                    botao.interactable = true;
                    fundoImg.sprite = spriteFundo;
                    preço.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    botao.interactable = false;                   
                    preço.text = null;

                    Color color = image.color;
                    color.a = 0f;
                    image.color = color;

                    fundoImg.sprite = planta.lockSprite;
                    preço.transform.parent.gameObject.SetActive(false);
                }
            }

            if(adubo != null)
            {
                //if (adubo.liberado)
               // {
                    //nome.text = adubo.tipoDoAdubo.ToString();
                    //Color color = image.color;
                    //color.a = 1f;
                    //image.color = color;

                    preço.text = adubo.preco.ToString();
                    image.sprite = adubo.sprite;
                    botao.interactable = true;
                    fundoImg.sprite = spriteFundo;
                    preço.transform.parent.gameObject.SetActive(true);
               // }
                //else
                //{
                //    botao.interactable = false;                   
                //   // nome.text = null;
                //    preço.text = null;
                //    Color color = image.color;
                //    color.a = 0f;
                //    image.color = color;
                //    fundoImg.sprite = adubo.lockSprite;
                //    preço.transform.parent.gameObject.SetActive(false);
                //}
            }

            if(cenarioItem != null)
            {
                if (cenarioItem.Usado 
                    //|| cenarioItem.paraSave == 1
                    )
                {
                    
                    botao.interactable = false;
                    nome.text = cenarioItem.tipoCenarioItem.ToString();
                    preço.text = cenarioItem.preco.ToString();
                    image.sprite = cenarioItem.spriteLoja;
                    //cenarioItem.paraSave = 1; 
                }
                else
                {
                    botao.interactable = true;
                    nome.text = cenarioItem.tipoCenarioItem.ToString();
                    preço.text = cenarioItem.preco.ToString();
                    image.sprite = cenarioItem.spriteLoja;
                }
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adubacao : MonoBehaviour
{
    public Adubo adubo;
    public Vida vida;
    public Text text;
    public int amount;
    public FeedbackNmb feedbackNmb;
    public Terra terra;

    private Image image;
    private Button botao;
    bool click;
    private void Start()
    {
        botao = GetComponent<Button>();
        image = GetComponent<Image>();
        terra.fazendeiro.OnEndAction+=RecuperarVida;
    }
    private void Update()
    {
        amount = adubo.quantidadePossuida;
        //if (adubo.liberado)
        //{
            BotaoOn();
           image.sprite = adubo.sprite;
            text.text = amount.ToString();

       // }
        //else if(!adubo.liberado)
        //{
        //    image.sprite = adubo.lockSprite;
        //    text.text = null;
        //}
        
    }
    public void BotaoOn()
    {
        if (adubo.quantidadePossuida > 0)
        {
           botao.interactable = true;
        }
        else
        {
            botao.interactable = false;
        }


    }

    public void ClickButton()
    {
        click = true;
    }
    public void RecuperarVida()
    {

        if (terra.adubo && click)
        {
            feedbackNmb.tipo = TipoFeed.Vida;
            feedbackNmb.number = adubo.quantidaddeQueRecuperaAVida;
            feedbackNmb.feedback = "Adubar";
            feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
            feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
            vida.SetHealth(false, adubo.quantidaddeQueRecuperaAVida);

            if(adubo.quantidadePossuida-4 < 0)
                adubo.quantidadePossuida = 0;
            else
                adubo.quantidadePossuida -= 4;
            
            terra.adubo = false;
            click = false;
        }
       
    }
}

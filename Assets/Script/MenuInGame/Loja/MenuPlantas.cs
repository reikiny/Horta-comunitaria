using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoItem { Planta, Adubo, Cenario}
public class MenuPlantas : MonoBehaviour
{
    public Item itemMostrado;
    public Adubo aduboMostrado;
    public CenarioItem itemCenarioMostrado;
    public TipoItem tipoItem;
    public Text quantia, nome, valor, info, tipoPlanta, precoStatico, upgradeTexto;
    public Button botaoCompra, mais,menos;
    int quantidadeEscolhida;
    public Image image;
    public UpgradeCenário upgrade;
    public FeedbackNmb feedback;
    public AudioSource source;
    public AudioClip cash;
    private void OnEnable()
    {
        StartCoroutine(SlowUpdate());
    }
    IEnumerator SlowUpdate()
    {
        while (true)
        {
            if(tipoItem == TipoItem.Cenario)
            {

                precoStatico.text = itemCenarioMostrado.preco.ToString();
                valor.text = itemCenarioMostrado.preco.ToString();
                quantia.text = null;
                mais.gameObject.SetActive(false);
                menos.gameObject.SetActive(false);

                if(itemCenarioMostrado.Usado || Pontos.scoreNumber < itemCenarioMostrado.preco)
                    botaoCompra.interactable = false;
                else 
                    botaoCompra.interactable = true;

            }
            else
            {
                upgradeTexto.text = null;

                if(!mais.gameObject.activeSelf)
                    mais.gameObject.SetActive(true);

                if(!menos.gameObject.activeSelf)
                    menos.gameObject.SetActive(true);


                quantia.text = quantidadeEscolhida.ToString();

                if (tipoItem == TipoItem.Planta)
                {
                    precoStatico.text = itemMostrado.preco.ToString();

                    if (quantidadeEscolhida > 0)
                    {
                        valor.text =(itemMostrado.preco * quantidadeEscolhida).ToString();
                    }
                    else valor.text = itemMostrado.preco.ToString();

                    if (Pontos.scoreNumber >= quantidadeEscolhida * itemMostrado.preco && quantidadeEscolhida > 0)
                    {
                        botaoCompra.interactable = true;
                    }
                    else
                    {
                        botaoCompra.interactable = false;
                    }

                }
                else if (tipoItem == TipoItem.Adubo)
                {
                    precoStatico.text = aduboMostrado.preco.ToString();

                    if (quantidadeEscolhida > 0)
                    {
                        valor.text = (aduboMostrado.preco * quantidadeEscolhida).ToString();
                    }
                    else valor.text =aduboMostrado.preco.ToString();

                    if (Pontos.scoreNumber >= quantidadeEscolhida * aduboMostrado.preco && quantidadeEscolhida > 0)
                    {
                        botaoCompra.interactable = true;
                    }
                    else
                    {
                        botaoCompra.interactable = false;
                    }
                }
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Mais()
    {
        quantidadeEscolhida++;                    
    }

    public void Menos()
    {
        if (quantidadeEscolhida > 0 )
            quantidadeEscolhida--;

    }

    public void Compra()
    {


        if (tipoItem == TipoItem.Planta)
        {
            if (Pontos.scoreNumber >= quantidadeEscolhida * itemMostrado.preco && itemMostrado.liberada)
            {
                Pontos.scoreNumber -= quantidadeEscolhida * itemMostrado.preco;
                itemMostrado.quantidadePossuida += quantidadeEscolhida;
               

                //feedback
                feedback.tipo = TipoFeed.Pontos;
                feedback.number = -(quantidadeEscolhida * itemMostrado.preco);
                feedback.feedback = "Compra";
                feedback.targetInicial = botaoCompra.transform;
                feedback.numeroGO.transform.parent.gameObject.SetActive(true);

                quantidadeEscolhida = 0;
                source.PlayOneShot(cash);
            }
        }
        else if (tipoItem == TipoItem.Adubo)
        {
            if (Pontos.scoreNumber >= quantidadeEscolhida * aduboMostrado.preco)
            {
                Pontos.scoreNumber -= quantidadeEscolhida * aduboMostrado.preco;
                aduboMostrado.quantidadePossuida += quantidadeEscolhida;
               

                //feedback
                feedback.tipo = TipoFeed.Pontos;
                feedback.number = -(quantidadeEscolhida * aduboMostrado.preco);
                feedback.feedback = "Compra";
                feedback.targetInicial = botaoCompra.transform;
                feedback.numeroGO.transform.parent.gameObject.SetActive(true);

                quantidadeEscolhida = 0;
                source.PlayOneShot(cash);
            }
        }
        else if (tipoItem == TipoItem.Cenario)
        {
            if (Pontos.scoreNumber >= itemCenarioMostrado.preco && !itemCenarioMostrado.Usado)
            {
                Pontos.scoreNumber -= itemCenarioMostrado.preco;

               

                //feedback
                upgrade.FazerUpgrade(itemCenarioMostrado);
                feedback.tipo = TipoFeed.Pontos;
                feedback.number = -(itemCenarioMostrado.preco);
                feedback.feedback = "Compra";
                feedback.targetInicial = botaoCompra.transform;
                feedback.numeroGO.transform.parent.gameObject.SetActive(true);

                quantidadeEscolhida = 0;
                source.PlayOneShot(cash);
            }
        }


    }

  
    public void Plantinha(Item itemzin)
    {
        if (itemzin.liberada)
        {
            quantidadeEscolhida = 0;

            itemMostrado = itemzin;

            tipoItem = TipoItem.Planta;

            image.sprite = itemMostrado.sprite;

            nome.text = itemMostrado.nomeDaPlanta.ToString();

            tipoPlanta.text = itemMostrado.tipoDaPlanta.ToString();

            info.text = itemMostrado.descricao;
        }
        
    }

    public void Adubinho(Adubo adubin)
    {
        //if (adubin.liberado)
       // {
            quantidadeEscolhida = 0;

            aduboMostrado = adubin;

            tipoItem = TipoItem.Adubo;

            image.sprite = aduboMostrado.sprite;

            nome.text = aduboMostrado.tipoDoAdubo.ToString();

            info.text = aduboMostrado.descricao;

            tipoPlanta.text = "Adubo";
      //  }
    }

    public void Aguinha(CenarioItem cena)
    {

            quantidadeEscolhida = 0;

            itemCenarioMostrado = cena;

            tipoItem = TipoItem.Cenario;

            image.sprite = itemCenarioMostrado.spriteLoja;

            nome.text = itemCenarioMostrado.tipoCenarioItem.ToString();

            tipoPlanta.text = "Melhoria";

            info.text = itemCenarioMostrado.descricao;

            upgradeTexto.text = itemCenarioMostrado.melhoria;


    }
}

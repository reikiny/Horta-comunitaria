using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoItem { Planta, Adubo, Irrigacao }
public class MenuPlantas : MonoBehaviour
{
    public Item itemMostrado;
    public Adubo aduboMostrado;
    public Irrigacao irrigacao;
    public TipoItem tipoItem;
    public Text quantia, nome, valor, info, tipoPlanta, precoStatico;
    public Button botaoCompra, mais,menos;
    int quantidadeEscolhida;
    public Image image;


    IEnumerator Start()
    {
        while (true)
        {
            quantia.text = quantidadeEscolhida.ToString();
            
            if (tipoItem == TipoItem.Planta)
            {
                precoStatico.text = itemMostrado.preco.ToString();

                if (quantidadeEscolhida > 0)
                {
                    valor.text = "Valor: " + (itemMostrado.preco * quantidadeEscolhida) + " pontos";
                }
                else valor.text = "Valor: " + itemMostrado.preco + " pontos";

                if (Pontos.scoreNumber >= quantidadeEscolhida * itemMostrado.preco)
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
                    valor.text = "Valor: " + (aduboMostrado.preco * quantidadeEscolhida) + " pontos";
                }
                else valor.text = "Valor: " + aduboMostrado.preco + " pontos";

                if (Pontos.scoreNumber >= quantidadeEscolhida * aduboMostrado.preco)
                {
                    botaoCompra.interactable = true;
                }
                else
                {
                    botaoCompra.interactable = false;
                }
            }
            else if (tipoItem == TipoItem.Irrigacao)
            {
                precoStatico.text = irrigacao.preco.ToString();

                if (quantidadeEscolhida > 0)
                {
                    valor.text = "Valor: " + (irrigacao.preco * quantidadeEscolhida) + " pontos";
                }
                else valor.text = "Valor: " + irrigacao.preco + " pontos";

                if (Pontos.scoreNumber >= quantidadeEscolhida * irrigacao.preco)
                {
                    botaoCompra.interactable = true;
                }
                else
                {
                    botaoCompra.interactable = false;
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
                quantidadeEscolhida = 0;

            }
        }
        else if (tipoItem == TipoItem.Adubo)
        {
            if (Pontos.scoreNumber >= quantidadeEscolhida * aduboMostrado.preco && aduboMostrado.liberado)
            {
                Pontos.scoreNumber -= quantidadeEscolhida * aduboMostrado.preco;
                aduboMostrado.quantidadePossuida += quantidadeEscolhida;
                quantidadeEscolhida = 0;

            }
        }
        else if (tipoItem == TipoItem.Irrigacao)
        {
            if (Pontos.scoreNumber >= quantidadeEscolhida * irrigacao.preco && irrigacao.liberada)
            {
                Pontos.scoreNumber -= quantidadeEscolhida * irrigacao.preco;
                irrigacao.quantidadePossuida += quantidadeEscolhida;
                quantidadeEscolhida = 0;

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

            image.sprite = itemMostrado.lojaSprite;

            nome.text = itemMostrado.nomeDaPlanta.ToString();

            tipoPlanta.text = itemMostrado.tipoDaPlanta.ToString();

            info.text = itemMostrado.descricao;
        }
        
    }

    public void Adubinho(Adubo adubin)
    {
        if (adubin.liberado)
        {
            quantidadeEscolhida = 0;

            aduboMostrado = adubin;

            image.sprite = aduboMostrado.spriteLoja;

            nome.text = aduboMostrado.tipoDoAdubo.ToString();

            info.text = aduboMostrado.descricao;

            tipoPlanta.text = "Adubo";
        }
    }

    public void Aguinha(Irrigacao aguin)
    {
        if (aguin.liberada)
        {
            quantidadeEscolhida = 0;

            irrigacao = aguin;

            image.sprite = irrigacao.spriteLoja;

            nome.text = irrigacao.tipoDeIrrigacao.ToString();

            tipoPlanta.text = "Irrigação";

            info.text = irrigacao.descricao;

        }
    }
}

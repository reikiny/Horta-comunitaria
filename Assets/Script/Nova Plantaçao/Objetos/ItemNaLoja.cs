
using UnityEngine;
using UnityEngine.UI;

public class ItemNaLoja : MonoBehaviour
{
    public PlantImag plantImag;
    public Item item;
    public Text quantia, nome, valor, info;
    public Button botaoCompra;
    int quantidadeEscolhida;

    void Start()
    {
        GetComponent<Image>().sprite = item.bestiarioSprite;
    }

    void Update()
    {

        if (plantImag == PlantImag.SEMENTE)
        {
            GetComponent<Image>().sprite = item.bestiarioSprite;
        }
        else if (plantImag == PlantImag.BLOQUEADALOJA)
        {
            GetComponent<Image>().sprite = item.bestiarioLockSprite;
        }


        if (item.liberada)
        {
            plantImag = PlantImag.SEMENTE;
            quantia.text = quantidadeEscolhida.ToString();
            nome.text = item.nomeDaPlanta.ToString();
            valor.text = item.preco.ToString();
            info.text = item.descricao;

            if (Pontos.scoreNumber >= quantidadeEscolhida * item.preco && quantidadeEscolhida > 0)
                botaoCompra.interactable = true;
            else
                botaoCompra.interactable = false;
        }
        else
        {
            plantImag = PlantImag.BLOQUEADALOJA;
            quantia.text = null;
            nome.text = null;
            valor.text = null;
            info.text = null;
            botaoCompra.interactable = false;
        }
    }

    public void Mais()
    {
        quantidadeEscolhida++;
    }

    public void Menos()
    {
        if (quantidadeEscolhida > 0)
            quantidadeEscolhida--;
    }

    public void Compra()
    {
        if (Pontos.scoreNumber >= quantidadeEscolhida * item.preco && item.liberada)
        {
            Pontos.scoreNumber -= quantidadeEscolhida * item.preco;
            item.quantidadePossuida += quantidadeEscolhida;
            quantidadeEscolhida = 0;
        }

    }

}

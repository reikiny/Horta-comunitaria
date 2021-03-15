using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpgradeCenário : MonoBehaviour
{
    public GameObject[] imagens;
    public Plantar plantar;
    public Fazendeiro fazendeiro;
    public Vida[] vidas;
    
    public void FazerUpgrade(CenarioItem cenario)
    {
        cenario.Usado = true;
        switch (cenario.tipoCenarioItem)
        {
            case TipoCenarioItem.Xavier:

                FazendeiroVeloz();

                break;
            case TipoCenarioItem.Chico:

                FazendeiroMaisVeloz();

                break;
            case TipoCenarioItem.Plantinhas:

                FazendaRapida();

                break;
            case TipoCenarioItem.Animais:

                FazendaMaisRapida();

                break;
            case TipoCenarioItem.PANC1:

                MaiorPontuacao();
                break;
            case TipoCenarioItem.PANC2:

                MuitoMaiorPontuacao();

                break;
            case TipoCenarioItem.Cisterna:

                VidaCresce();

                break;
            case TipoCenarioItem.Gotejamento:

                VidaCresceMais();

                break;
        }
    }
    public void FazendeiroVeloz()
    {
        //personagem1
        fazendeiro.tempoParaFazer *= 0.975f;
        imagens[3].SetActive(true);
    }

    public void FazendeiroMaisVeloz() 
    {
        //personagem2
        fazendeiro.tempoParaFazer *= 0.945f;
        imagens[4].SetActive(true);
    }

    public void FazendaRapida()
    {
        //plantinhas
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            plantar.itensDisplay[i].item.tempoParaCrescer *= 0.975f;
        }
        imagens[7].SetActive(true);
    }

    public void FazendaMaisRapida()
    {
        //animais
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            plantar.itensDisplay[i].item.tempoParaCrescer *= 0.945f;
        }
        imagens[6].SetActive(true);

    }

    public void MaiorPontuacao()
    {
        //panc1
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            plantar.itensDisplay[i].item.ponto += 2;
        }
        imagens[1].SetActive(true);
    }

    public void MuitoMaiorPontuacao()
    {
        //panc2
        for (int i = 0; i < plantar.itensDisplay.Length; i++)
        {
            plantar.itensDisplay[i].item.ponto += 5;
        }
        imagens[2].SetActive(true);
    }

    public void VidaCresce()
    {
        //cisterna
        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].maxHealth += 1;
        }
        imagens[0].SetActive(true);
    }

    public void VidaCresceMais()
    {
        //gotejamento
        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].maxHealth += 2;
        }
        imagens[5].SetActive(true);
    }


}

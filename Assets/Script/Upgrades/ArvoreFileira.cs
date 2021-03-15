//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ArvoreFileira : MonoBehaviour
//{
//    public Button[] adubagem;
//    public Button[] irrigas;
//    public bool[] jaUsouAd;
//    public bool[] jaUsouIr;
//    public Upgrades[] upgradeAdubo;
//    public Upgrades[] upgradeIrrigacao;
//    Adubo adubo;
//    CenarioItem irrigacao;
//    public Player player;

//    void Start()
//    {
//        for (int i = 0; i < adubagem.Length; i++)
//        {
//            adubagem[i].interactable = false;
//            irrigas[i].interactable = false;
//        }
//        player.OnLiberarAdubo += FileiraAdub;
//        player.OnLiberarIrrigacao += FileiraIrr;
//    }

//    public void Update()
//    {
//        if(adubo != null)
//        {
//            switch (adubo.tipoDoAdubo)
//            {
//                case TipoDeAdubo.Cavalo:
//                    for (int i = 0; i < adubagem.Length; i++)
//                    {
//                        if (upgradeAdubo[i].Clicou && i == 0)
//                        {
//                            adubo.liberado = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 3)
//                        {
//                            adubo.liberado2 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 6)
//                        {
//                            adubo.liberado3 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                    }
//                    break;
//                case TipoDeAdubo.Galinha:
//                    for (int i = 0; i < adubagem.Length; i++)
//                    {

//                        if (upgradeAdubo[i].Clicou && i == 1)
//                        {
//                            adubo.liberado = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 4)
//                        {
//                            adubo.liberado2 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 7)
//                        {
//                            adubo.liberado3 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }

//                    }
//                    break;
//                case TipoDeAdubo.Compostagem:
//                    for (int i = 0; i < adubagem.Length; i++)
//                    {
//                        if (upgradeAdubo[i].Clicou && i == 2)
//                        {
//                            adubo.liberado = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 5)
//                        {
//                            adubo.liberado2 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                        else if (upgradeAdubo[i].Clicou && i == 8)
//                        {
//                            adubo.liberado3 = true;
//                            jaUsouAd[i] = true;
//                            adubagem[i].interactable = false;
//                            adubagem[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            adubo = null;
//                        }
//                    }
//                    break;
//            }
//        }else
//        {
//            for (int i = 0; i < adubagem.Length; i++)
//            {
//                if(!jaUsouAd[i])
//                    adubagem[i].interactable = false;
//            }
//        }
        
//        if(irrigacao != null)
//        {
//            switch (irrigacao.tipoCenarioItem)
//            {
//                case TipoCenarioItem.Cisterna:
//                    for (int i = 0; i < irrigas.Length; i++)
//                    {
//                        if (upgradeIrrigacao[i].Clicou && i == 0)
//                        {
//                            irrigacao.liberada = true;
//                            jaUsouIr[i] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[3].Clicou && i == 3)
//                        {
//                            irrigacao.liberada2 = true;
//                            jaUsouIr[3] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[6].Clicou && i == 6)
//                        {
//                            irrigacao.liberada3 = true;
//                            jaUsouIr[6] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                    }
//                    break;
//                case TipoCenarioItem.GarrafaPet:
//                    for (int i = 0; i < irrigas.Length; i++)
//                    {

//                        if (upgradeIrrigacao[1].Clicou && i == 1)
//                        {
//                            irrigacao.liberada = true;
//                            jaUsouIr[1] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[4].Clicou && i == 4)
//                        {
//                            irrigacao.liberada2 = true;
//                            jaUsouIr[4] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[7].Clicou && i == 7)
//                        {
//                            irrigacao.liberada3 = true;
//                            jaUsouIr[7] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                    }
//                    break;
//                case TipoCenarioItem.Gotejamento:
//                    for (int i = 0; i < irrigas.Length; i++)
//                    {

//                        if (upgradeIrrigacao[2].Clicou && i == 2)
//                        {
//                            irrigacao.liberada = true;
//                            jaUsouIr[2] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[5].Clicou && i == 5)
//                        {
//                            irrigacao.liberada2 = true;
//                            jaUsouIr[5] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                        else if (upgradeIrrigacao[8].Clicou && i == 8)
//                        {
//                            irrigacao.liberada3 = true;
//                            jaUsouIr[8] = true;
//                            irrigas[i].interactable = false;
//                            irrigas[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                            irrigacao = null;
//                        }
//                    }
//                    break;

//            }
//        }
//        else
//        {
//            for (int i = 0; i < irrigas.Length; i++)
//            {
//                if (!jaUsouIr[i])
//                    irrigas[i].interactable = false;
//            }
//        }

//    }
//    public void FileiraAdub (Adubo adubin)
//    {
//        adubo = adubin;
//        switch (adubo.tipoDoAdubo)
//        {
//            case TipoDeAdubo.Cavalo:
//                for (int i = 0; i < adubagem.Length; i++)
//                {
//                    if ((i == 0 || i == 3 || i == 6))
//                    {
//                        if (!jaUsouAd[i])
//                        {
//                            adubagem[i].interactable = true;
//                        }
//                        else
//                        {
//                            adubagem[i].interactable = false;
//                        }
                        
//                    }
//                }
//                break;
//            case TipoDeAdubo.Galinha:
//                for (int i = 0; i < adubagem.Length; i++)
//                {
//                    if((i == 1 || i == 4 || i == 7))
//                    {
//                        if(jaUsouAd[i - 1] && !jaUsouAd[i])
//                        {
//                            adubagem[i].interactable = true;
//                        }
//                        else
//                        {
//                            adubagem[i].interactable = false;
//                        }
                       
//                    }
//                }
//                break;
//            case TipoDeAdubo.Compostagem:
//                for (int i = 0; i < adubagem.Length; i++)
//                {
//                    if ((i == 2 || i == 5 || i == 8))
//                    {
//                        if (jaUsouAd[i - 1] && !jaUsouAd[i])
//                        {
//                            adubagem[i].interactable = true;
//                        }
//                        else
//                        {
//                            adubagem[i].interactable = false;
//                        }
                       
//                    }
//                }
//                break;
//        }
//    }

//    public void FileiraIrr(CenarioItem irri)
//    {
//        irrigacao = irri;
//        switch (irrigacao.tipoCenarioItem)
//        {
//            case TipoCenarioItem.Cisterna:
//                for (int i = 0; i < irrigas.Length; i++)
//                {
//                    if ((i == 0 || i == 3 || i == 6))
//                    {
//                        if (!jaUsouIr[i])
//                        {
//                            irrigas[i].interactable = true;
//                        }
//                        else
//                        {
//                            irrigas[i].interactable = false;
//                        }
//                    }
//                }
//                break;
//            case TipoCenarioItem.GarrafaPet:
//                for (int i = 0; i < irrigas.Length; i++)
//                {
//                    if ((i == 1 || i == 4 || i == 7))
//                    {
//                        if (!jaUsouIr[i])
//                        {
//                            irrigas[i].interactable = true;
//                        }
//                        else
//                        {
//                            irrigas[i].interactable = false;
//                        }
//                    }
//                }
//                break;
//            case TipoCenarioItem.Gotejamento:
//                for (int i = 0; i < irrigas.Length; i++)
//                {
//                    if ((i == 2 || i == 5 || i == 8))
//                    {
//                        if (!jaUsouIr[i])
//                        {
//                            irrigas[i].interactable = true;
//                        }
//                        else
//                        {
//                            irrigas[i].interactable = false;
//                        }
//                    }
//                }
//                break;

//        }
        
//    }
//}

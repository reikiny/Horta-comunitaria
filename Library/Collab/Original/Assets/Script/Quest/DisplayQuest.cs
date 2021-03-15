using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class DisplayQuest : MonoBehaviour
{

    public Player player;
    public ProgressBar[] progressBar;
    public ProgressBar progressPrim;
    public Text pontos;
    //public GameObject[] rewardItem;
    public GameObject rewardPlanta, rewardAdubo, rewardIrrigacao, rewardPonto;
    public Button giveReward;


    void Update()
    {
        AtualizarProgressBar();
        Reward();
        
    }

    void AtualizarProgressBar()
    {
        if (player.quest != null)
        {
            progressPrim.max = player.quest.objetivos[0].requiredAmount;
            progressPrim.current = player.quest.objetivos[0].currentAmount;

            for (int i = 0; i < progressBar.Length; i++)
            {
                if (i >= player.quest.objetivos.Length-1)
                    progressBar[i].gameObject.SetActive(false);
                else
                    progressBar[i].gameObject.SetActive(true);
            }

            for (int i = 1; i < player.quest.objetivos.Length; i++)
            {
                progressBar[i-1].max = player.quest.objetivos[i].requiredAmount;
                progressBar[i-1].current = player.quest.objetivos[i].currentAmount;
                progressBar[i - 1].icone.sprite = player.quest.objetivos[i].planta.plantarSprite;
            }
            
        }
    }

    void Reward()
    {
        if (player.quest != null)
        {
            //Planta
            if (player.quest.itemLiberado != null)
            {
                    rewardPlanta.transform.GetChild(0).GetComponent<Image>().sprite = player.quest.itemLiberado.sprite;
            }
            else
            {
                    rewardPlanta.SetActive(false);
            }
            //Irrigaçao
            if (player.quest.irrigacaoLiberada != null)
            {
                    rewardIrrigacao.transform.GetChild(0).GetComponent<Image>().sprite = player.quest.irrigacaoLiberada.sprite;
            }
            else
            {
                    rewardIrrigacao.SetActive(false);
            }
            //Adubo
            if (player.quest.aduboLiberado != null)
            {
                    rewardAdubo.transform.GetChild(0).GetComponent<Image>().sprite = player.quest.aduboLiberado.sprite;

            }
            else
            {
                    rewardAdubo.SetActive(false);
            }
            //Ponto
            rewardPonto.transform.GetChild(1).GetComponent<Image>().color = Color.red;
            pontos.text = player.quest.pontos.ToString();

            if (player.quest.Completada)
            {
                giveReward.interactable = true;
            }
            else giveReward.interactable = false;

        }
            
    }

    public void OnCompleteQuest()
    {
        if (player.quest != null)
            player.quest.LiberarItem();
    }

}


//for (int i = 0; i < rewardItem.Length; i++)
//{

//    if (player.quest.itemLiberado != null)
//    {
//        if (i == 0)
//            rewardItem[i].transform.GetChild(0).GetComponent<Image>().sprite = player.quest.itemLiberado.sprite;
//    }
//    else
//    {
//        if (i == 0)
//            rewardItem[i].SetActive(false);
//    }
//    if(player.quest.irrigacaoLiberada != null)
//    {
//        if (i == 1)
//            rewardItem[i].transform.GetChild(0).GetComponent<Image>().sprite = player.quest.aduboLiberado.sprite;
//    }
//    else
//    {
//        if (i == 1)
//            rewardItem[i].SetActive(false);
//    }
//    if(player.quest.aduboLiberado != null)
//    {
//        if(i==2)
//            rewardItem[i].transform.GetChild(0).GetComponent<Image>().sprite = player.quest.irrigacaoLiberada.sprite;

//    }
//    else
//    {
//        if (i == 2)
//            rewardItem[i].SetActive(false);
//    }
//    rewardItem[3].transform.GetChild(1).GetComponent<Image>().color = Color.red;
//}
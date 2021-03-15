using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayQuest : MonoBehaviour
{

    public Player player;
    public ProgressBar[] progressBar;
    public Text pontos, objetivo, titulo;
    public GameObject rewardPlanta, rewardPonto;
    public Button giveReward, acessarQuest;
    public AchievenmentGiver questGiver;
    public Sprite rotacao, vidaCheia, vegetais, tuberculos, frutiferas;
    public FeedbackNmb coin;
    public FeedbackNmb chave;
    public DialogueTrigger dialogoFinal;
    public GameObject chaveUI;
    public AudioSource source;
    public AudioClip termina;
    public QuestPop popGuia;
    private void OnEnable()
    {
        StartCoroutine(SlowUpdate());
    }
    private IEnumerator SlowUpdate()
    {
        while (true)
        {
            AtualizarProgressBar();
            Reward();
            AtualizarQuest();
            yield return new WaitForSeconds(0.1f);
        }
    }
    void AtualizarProgressBar()
    {

        if (player.quest != null)
        {
            
            for (int i = 0; i < progressBar.Length; i++)
            {
                if (i >= player.quest.objetivos.Length)
                    progressBar[i].gameObject.SetActive(false);
                else
                    progressBar[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < player.quest.objetivos.Length; i++)
            {                    
                progressBar[i].max = player.quest.objetivos[i].requiredAmount;
                progressBar[i].current = player.quest.objetivos[i].currentAmount;
                if(player.quest.objetivos[i].goalType == GoalType.Colher || player.quest.objetivos[i].goalType == GoalType.Plantar)
                {
                    progressBar[i].icone.color = Color.white;
                    //avisando oq precisa ser feito
                    objetivo.text = player.quest.objetivos[i].goalType.ToString();
                    //colocando as sprites
                    progressBar[i].icone.sprite = player.quest.objetivos[i].planta.sprite;
                    progressBar[i].tipo.text = player.quest.objetivos[i].planta.nomeDaPlanta.ToString();

                }
                else if(player.quest.objetivos[i].goalType == GoalType.ColherCategoria)
                {
                    progressBar[i].icone.color = Color.white;
                    progressBar[i].tipo.text = player.quest.objetivos[i].planta.tipoDaPlanta.ToString();
                    switch (player.quest.objetivos[i].planta.tipoDaPlanta)
                    {
                        case TipoDePlanta.Vegetais:
                            progressBar[i].icone.sprite = vegetais;
                            break;
                        case TipoDePlanta.Tuberculos:
                            progressBar[i].icone.sprite = tuberculos;
                            break;
                        case TipoDePlanta.Frutiferas:
                            progressBar[i].icone.sprite = frutiferas;
                            break;
    
                    }
                    
                }
                else if(player.quest.objetivos[i].goalType == GoalType.Rotação)
                {
                    progressBar[i].icone.color = Color.white;
                    progressBar[i].icone.sprite = rotacao;
                    progressBar[i].tipo.text = "Rotação";
                }
                else
                {
                    progressBar[i].icone.color = Color.green;
                    progressBar[i].tipo.text = "Vida Verde";
                    progressBar[i].icone.sprite = vidaCheia;
                }
                    
            }
            titulo.text = player.quest.Nome;
        }
        //else
        //{
        //    for (int i = 0; i < progressBar.Length; i++)
        //    {
        //        progressBar[i].gameObject.SetActive(false);
        //    }
        //    progressPrim.gameObject.SetActive(false);
        //    rewardPlanta.SetActive(false);
        //    rewardPonto.SetActive(false);

        //    giveReward.interactable = false;
        //}
       
    }
    void AtualizarQuest()
    {

    }
    void Reward()
    {
        if (player.quest != null)
        {
            //Planta
            if (player.quest.itemLiberado != null)
            {
                //rewardPlanta.transform.GetChild(0).GetComponent<Image>().sprite = onlockItem.sprite;
                rewardPlanta.SetActive(true);
            }
            else
            {
                    rewardPlanta.SetActive(false);
            }


            pontos.text = player.quest.pontos.ToString();
            rewardPonto.SetActive(true);

            if (player.quest.Completada)
            {
                giveReward.interactable = true;
                
            }
            else
            {
                giveReward.interactable = false;
            }

        }
            
    }

    public void OnCompleteQuest()
    {
        if (player.quest != null)
        {
            source.PlayOneShot(termina);
            questGiver.aceitar.interactable = false; 

            if(player.quest.itemLiberado == null)
            {
                questGiver.indice++;
                coin.tipo = TipoFeed.Pontos;
                coin.number = player.quest.pontos;
                coin.feedback = "Recompensa";
                coin.targetInicial = giveReward.transform;
                coin.numeroGO.transform.parent.gameObject.SetActive(true);
                questGiver.feedback.PegarQuest();
            }
            else
            {
                chaveUI.SetActive(true);
                player.quest.LiberarItem();
                popGuia.QuestPronta();
                //colocar aqui o feed que pra liberar o item
                acessarQuest.interactable = false;
                player.OnLiberarItem?.Invoke(player.quest.itemLiberado);
                questGiver.feedback.ColsultarQuest();

                coin.tipo = TipoFeed.Pontos;
                coin.number = player.quest.pontos;
                coin.feedback = "Recompensa";
                coin.targetInicial = giveReward.transform;
                coin.numeroGO.transform.parent.gameObject.SetActive(true);

                chave.tipo = TipoFeed.Pontos;
                chave.number = 1;
                chave.feedback = "Chave";
                //coloca um pouco pra esquerda pra ficar visivel
                Transform target = giveReward.transform;
                target.position = new Vector3(giveReward.transform.position.x -2f, giveReward.transform.position.y,giveReward.transform.position.z);

                chave.targetInicial = giveReward.transform;
                chave.numeroGO.transform.parent.gameObject.SetActive(true);

            }         


            //caso tenha terminado todas as quests ele desativa e pode ativar uma fala
            if (questGiver.indice >= questGiver.quests.Length && questGiver.tutorial == ESTANOTUTORIAL.Nao)
            {
                dialogoFinal.dialogueManager = questGiver.dialogueManager;
                dialogoFinal.TriggerDialogue();
                questGiver.OpenQuestWindow();
                
                acessarQuest.transform.parent.gameObject.SetActive(false);
            }
            else if(questGiver.tutorial == ESTANOTUTORIAL.Sim)
            {

            }
            player.quest = null;
        }
            
    }


}



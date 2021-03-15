using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ESTANOTUTORIAL
{
    Sim,
    Nao
}
public class AchievenmentGiver : MonoBehaviour
{
    public Quest[] quests;

    public GameObject achievenmentWindow;
    public Text titleText;
    public Text descriptionText;
    public Text pontosText;
    public Text recompensa;
    public GameObject desbloqueio;

    public Player player;
    public Button aceitar;
    public int indice;

    public DialogueManager dialogueManager;
    public GameObject consultarQuest;
    public ESTANOTUTORIAL tutorial;
    public QuestPop feedback;
    public GameObject attquest;
    private void Start()
    {
        //StartCoroutine(SlowUpdate());
        dialogueManager.OnEndDialogue += EndDialogue;
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].dialogo.dialogueManager = dialogueManager;
        }
    }
    //IEnumerator SlowUpdate()
    //{
    //    while (true)
    //    {
    //        if (player.quest == null)
    //        {
    //            questOpener.interactable = true;
    //            questConsult.interactable = false;

    //        }
    //        else
    //        {
    //            questConsult.interactable = true;
    //            questOpener.interactable = false;
    //        }
    //        yield return new WaitForSeconds(1f);
    //    }
            
    //}

    public void EndDialogue()
    {
        aceitar.interactable = true;
    }
    public void OpenQuestWindow()
    {
        if(player.quest != null)
        {
            consultarQuest.SetActive(true);
            achievenmentWindow.SetActive(false);
        }
        else
        {
            consultarQuest.SetActive(false);
            achievenmentWindow.SetActive(true);


            feedback.ColsultarQuest();
            attquest.SetActive(true);
            if (indice < quests.Length)
            {
                if (quests[indice].itemLiberado != null)
                    desbloqueio.SetActive(true);
                else
                    desbloqueio.SetActive(false);

                quests[indice].dialogo.TriggerDialogue();
                titleText.text = quests[indice].Nome;
                descriptionText.text = quests[indice].Descricao;
                pontosText.text = "+" + quests[indice].pontos;
                recompensa.text = "Recompensas";
            }
            else
            {
                if(tutorial == ESTANOTUTORIAL.Nao)
                {
                    desbloqueio.SetActive(false);
                    pontosText.text = null;
                    recompensa.text = null;
                    titleText.text = "Despedida";
                    descriptionText.text = "Ser o novo cuidador";
                }
               
            }
            //}
        }


    }

     public void QuestAceita()
    {
        if (indice < quests.Length)
        {
            for (int i = 0; i < quests[indice].objetivos.Length; i++)
            {
                quests[indice].objetivos[i].player = player;
                
            }
            quests[indice].Ativo = true;
            
            player.quest = quests[indice];
            quests[indice].Comeca();
        }
        attquest.SetActive(true);
        achievenmentWindow.SetActive(false);
       
    }

 
}

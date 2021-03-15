using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievenmentGiver : MonoBehaviour
{
    public Quest quest;

    public GameObject achievenmentWindow;
    public Text titleText;
    public Text descriptionText;
    public Text pontosText;
    public Text recompensa;

    public Player player;

    public void OpenQuestWindow()
    {
        achievenmentWindow.SetActive(true);

        titleText.text = quest.Nome;
        descriptionText.text = quest.Descricao;
        pontosText.text = "+"+quest.pontos;
        recompensa.text = "Recompensas";

    }

     public void QuestAceita()
    {
        for (int i = 0; i < quest.objetivos.Length; i++)
        {
            quest.objetivos[i].player = player;
        }
        quest.Ativo = true;
        achievenmentWindow.SetActive(false);
        player.quest = quest;
        quest.Comeca();
    }

 
}

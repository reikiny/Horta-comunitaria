using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizarQuest : MonoBehaviour
{
    public Player player;
    public QuestPop pop;

    private void OnEnable()
    {
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(player.quest != null)
            {
                player.quest.CheckGoals();
                if (player.quest.Completada)
                {
                    pop.QuestPronta();
                    gameObject.SetActive(false);
                }
            }
            
               
        }
    }
}

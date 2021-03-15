using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Nova Quest", menuName = "Quests")]
public class Quest : ScriptableObject
{
    public bool Ativo;
    public bool Completada;
    public string Nome;
    [TextArea]
    public string Descricao;
    public int pontos;
    public Item itemLiberado;
    public AchievenmentGoal[] objetivos;
    public DialogueTrigger dialogo;

    public void Comeca()
    {
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].Iniciada();

        }

    }


    public void CheckGoals()
    {

        for (int i = 0; i < objetivos.Length; i++)
        {
            
                if (!objetivos[i].IsReached())
                {
                     Completada = false;
                }
                else
                {                    
                    Completada = true;
                }
        }
    }

    public void LiberarItem()
    {
       
        Pontos.scoreNumber += pontos;
        Ativo = false;

        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].Terminada();
            Save.AplicarOload = 1;
        }
    }
}

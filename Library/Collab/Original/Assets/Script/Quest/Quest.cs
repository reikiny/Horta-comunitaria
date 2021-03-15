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
    public Adubo aduboLiberado;
    public Irrigacao irrigacaoLiberada;
    public AchievenmentGoal[] objetivos;

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
            if (objetivos[i].goalType == GoalType.Primaria)
            {
                if (objetivos[i].IsReached())
                {
                    //LiberarItem();
                    Completada = true;
                }
                else
                {
                    Completada = false;
                }
            }

        }
    }

    public void LiberarItem()
    {
        for (int i = 0; i < objetivos.Length; i++)
        {
            if (objetivos[i].goalType == GoalType.Secundaria)
            {
                if (!objetivos[i].IsReached())
                {

                }
                else
                {
                    Pontos.scoreNumber += pontos;

                }
            }


        }

        itemLiberado.liberada = true;


        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].Terminada();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievenmentGoal
{
    public GoalType goalType;
    //public NomeDaPlanta planta;
    public Item planta;
    public int requiredAmount;
    public int currentAmount;
    public Player player;

    public bool IsReached()
    {

        return (currentAmount >= requiredAmount);
    }

    public void Iniciada()
    {      
        if (goalType == GoalType.Secundaria)
        {
            player.OnPlantar += Plantada;
            player.OnColherItens += ColherItens;
        }
        else
        {
            player.OnColherPontos += ColherPontos;
        }

        
    }

    public void Terminada()
    {
        if (goalType == GoalType.Secundaria)
        {
            player.OnPlantar -= Plantada;
            player.OnColherItens -= ColherItens;
        }
        else
        {
            player.OnColherPontos -= ColherPontos;
        }
    }

    public void Plantada(NomeDaPlanta plantaPlantada, int quantidade)
    {
        if (planta.nomeDaPlanta == plantaPlantada)
        {
            currentAmount += quantidade;

        }
    }

    public void ColherPontos(int pontosColhidos)
    {
        currentAmount += pontosColhidos;
    }

    public void ColherItens(NomeDaPlanta plantaPlantada, int quantidade)
    {
        if (planta.nomeDaPlanta == plantaPlantada)
        {
            currentAmount += quantidade;

        }
    }

}
public enum GoalType
{
    Primaria,
    Secundaria
}

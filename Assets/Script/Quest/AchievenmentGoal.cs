
[System.Serializable]
public class AchievenmentGoal
{
    public GoalType goalType;
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
        if (goalType == GoalType.Plantar)
        {
            player.OnPlantar += Plantada;
        }
        else if (goalType == GoalType.Rotação)
        {
            player.OnRotacao += Combo;
        }
        else if(goalType == GoalType.VidaVerde)
        {
            player.OnSobrevida += SobreVida;
        }
        else
        {
            player.OnColherItens += ColherItens;
        }

    }

    public void Terminada()
    {
        if (goalType == GoalType.Plantar)
        {
            player.OnPlantar -= Plantada;
        }
        else if(goalType == GoalType.Rotação)
        {
            player.OnRotacao -= Combo;
        }
        else if (goalType == GoalType.VidaVerde)
        {
            player.OnSobrevida -= SobreVida;
        }
        else
        {
            player.OnColherItens -= ColherItens;
        }
    }

    public void Plantada(NomeDaPlanta plantaPlantada, int quantidade)
    {
        if (planta.nomeDaPlanta == plantaPlantada)
        {
            currentAmount += quantidade;

        }
    }

    public void ColherItens(Item plantaPlantada, int quantidade)
    {
        if (planta.nomeDaPlanta == plantaPlantada.nomeDaPlanta && goalType == GoalType.Colher)
        {
            currentAmount += quantidade;
        }
        if (planta.tipoDaPlanta == plantaPlantada.tipoDaPlanta && goalType == GoalType.ColherCategoria)
        {
            currentAmount += quantidade;
        }
    }

    public void SobreVida(int vida)
    {
        if(vida >=7 && goalType == GoalType.VidaVerde)
            currentAmount++;

    }
    public void Combo()
    {
        if (goalType == GoalType.Rotação)
            currentAmount++;
    }
}
public enum GoalType
{
    Plantar,
    Colher,
    ColherCategoria,
    VidaVerde,
    Rotação
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desenvolvedor : MonoBehaviour
{
    public Item[] item;
    public Adubo[] adubos;
   public void GanharMaisPontos()
    {
        Pontos.scoreNumber += 10000;
    }

    public void MuitosItens()
    {
        for (int i = 0; i < item.Length; i++)
        {
            item[i].quantidadePossuida += 100;
            //item[i].tempoParaCrescer = 10;
        }
        for (int i = 0; i < adubos.Length; i++)
        {
            adubos[i].quantidadePossuida += 100;
        }
    }
}

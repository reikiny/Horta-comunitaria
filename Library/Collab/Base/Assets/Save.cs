using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Save : MonoBehaviour
{
    public AchievenmentGiver giver;
    public Vida vidaDireita;
    public Vida vidaEsquerda;
    public Vida vidaMeio;

    public Quest[] quests;
    public Item[] items;
    public Adubo[] adubos;

    private void Start()
    {
        GetLoad();
        StartCoroutine(SlowUpdate());
    }

    public void SaveButton()
    {
        GetSave();
    }
    public void LoadButton()
    {
        GetLoad();
    }

    public void Delete()
    {
        DeleteSave();
    }

    private void GetSave()
    {
        PlayerPrefs.SetInt("Pontos", Pontos.scoreNumber);
        PlayerPrefs.SetInt("Achievenment", giver.indice);
        PlayerPrefs.SetInt("VidaEsquerda", vidaEsquerda.currentHealth);
        PlayerPrefs.SetInt("VidaMeio", vidaMeio.currentHealth);
        PlayerPrefs.SetInt("VidaDireita", vidaDireita.currentHealth);
        for (int i = 0; i < items.Length; i++)
        {
            PlayerPrefs.SetInt("Item" + i, items[i].quantidadePossuida);
        }
        for (int i = 0; i < adubos.Length; i++)
        {
            PlayerPrefs.SetInt("Adubo" + i, adubos[i].quantidadePossuida);
        }
        for (int i = 0; i < quests.Length; i++)
        {
            for (int b = 0; b < quests[i].objetivos.Length; b++)
            {
                PlayerPrefs.SetInt("Quest" + i, quests[i].objetivos[b].currentAmount);
            }
        }
    }
    private void GetLoad()
    {
        Pontos.scoreNumber = PlayerPrefs.GetInt("Pontos");
        giver.indice = PlayerPrefs.GetInt("Achievenment");
        vidaEsquerda.currentHealth = PlayerPrefs.GetInt("VidaEsquerda");
        vidaMeio.currentHealth = PlayerPrefs.GetInt("VidaMeio");
        vidaDireita.currentHealth = PlayerPrefs.GetInt("VidaDireita");

        for (int i = 0; i < items.Length; i++)
        {
            items[i].quantidadePossuida = PlayerPrefs.GetInt("Item" + i);
        }
        for (int i = 0; i < adubos.Length; i++)
        {
            adubos[i].quantidadePossuida = PlayerPrefs.GetInt("Adubo" + i);
        }
        for (int i = 0; i < quests.Length; i++)
        {
            for (int b = 0; b < quests[i].objetivos.Length; b++)
            {
                quests[i].objetivos[b].currentAmount = PlayerPrefs.GetInt("Quest" + i);
            }
            
        }
    }

    private void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    IEnumerator SlowUpdate()
    {
        yield return new WaitForSeconds(5f);
        GetSave();
    }
}

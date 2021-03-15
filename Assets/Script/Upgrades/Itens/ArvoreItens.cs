using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArvoreItens : MonoBehaviour
{
    public Upgrades[] upgradesScripts;
    private Item item;
    public int nmr = 0;
    public Player player;
    public Image bestiario;
    public Text[] text;
    public DisplayQuest quest;
    public AudioSource source;
    public AudioClip libera;
    public AudioClip abre;
    void Start()
    {
        for (int i = 0; i < upgradesScripts.Length; i++)
        {
            upgradesScripts[i].botao.interactable = false;
            upgradesScripts[i].OnClick += Onclick;
        }
        player.OnLiberarItem += ITEM;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        for (int i = 0; i < upgradesScripts.Length; i++)
        {
            if (upgradesScripts[i].jaUsou)
                upgradesScripts[i].botao.interactable = true;
        }
    }
    public void ITEM(Item itenzin)
    {
        item = itenzin;
        nmr++;
        upgradesScripts[nmr].botao.interactable = true;

    }

    void Onclick(Upgrades up, bool usado)
    {
        if (nmr > 0)
        {

            if (!upgradesScripts[nmr].jaUsou)
            {
                //liberar a proxima quest e deixar o player clicar no botao
                quest.questGiver.indice++;
                quest.acessarQuest.interactable = true;
                quest.questGiver.feedback.PegarQuest();
                quest.popGuia.ColsultarQuest();
                quest.chaveUI.SetActive(false);
                //liberar o item usado
                item.liberada = true;
                upgradesScripts[nmr].image.sprite = item.bestiarioSprite;
                upgradesScripts[nmr].jaUsou = true;
                
                source.PlayOneShot(libera);
                bestiario.gameObject.transform.parent.parent.gameObject.SetActive(true);
                bestiario.sprite = up.bestiarioImage;
                text[0].text = up.item.vidaConsumida.ToString();
                text[1].text = up.item.tempoParaCrescer.ToString();
                text[2].text = up.item.ponto.ToString();
                text[3].text = up.item.bestiarioDes;
                text[4].text = up.item.nomeDaPlanta.ToString();
                text[5].text = up.item.cientifico.ToString();
                text[6].text = up.item.tipoDaPlanta.ToString();
                text[7].text = up.item.nomeDaPlanta.ToString();
                text[8].text = up.item.tipoDaPlanta.ToString();
            }
        }

        if (usado) 
        {
            source.PlayOneShot(abre);
            bestiario.gameObject.transform.parent.parent.gameObject.SetActive(true);
            bestiario.sprite = up.bestiarioImage;
            text[0].text = up.item.vidaConsumida.ToString();
            text[1].text = up.item.tempoParaCrescer.ToString();
            text[2].text = up.item.ponto.ToString();
            text[3].text = up.item.bestiarioDes;
            text[4].text = up.item.nomeDaPlanta.ToString();
            text[5].text = up.item.cientifico.ToString();
            text[6].text = up.item.tipoDaPlanta.ToString();
            text[7].text = up.item.nomeDaPlanta.ToString();
            text[8].text = up.item.tipoDaPlanta.ToString();


        }

    }


}




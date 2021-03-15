using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sequencia : MonoBehaviour
{
    public DedoLoop dedoL;
    public DialogueTriggerTutorial trigger1;
    public DialogueTriggerTutorial[] triggers;
    public static int seqAcontecimento;
    
    public GameObject boxDialogue, painel,vida;

    public ItemDisplay itemDisplay;
    public DialogueManager dialogueManager;
    public DialogueManager dialogueQuest;
    public Plantar plantar;
    public Fazendeiro fazendeiro;
    //ir pra proxima cena
    public string start;
    public Transform terraMeio;

    public Button plantarDir, plantarEsq, plantarMeio, 
        painelItem, planta, painelSemente,
        ferramenta, painelFerramenta,adubo,ancinho,
        loja, compraAlface, painelLoja, painelCompra, melhorias, compraRepolho, mais, compra,
        inventario, itemLiberado, painelInventario,quest,aceitarQuest, receber;


    
    void Start()
    {
        dialogueQuest.OnEndDialogue += EndingDialogo;
        dialogueManager.OnEndDialogue += EndingDialogo;
        //ta triggando o proximo quando fazendeiro fizer uma ação
        fazendeiro.OnEndAction += EndingDialogo;
        plantar.terra.botao.AddListener(EndingDialogo);
        plantar.player.OnColherItens += COLHA;
        itemDisplay.OnFeedBack += EndingDialogo;
        StartCoroutine(LateStart());
       
    }

    //Ele ta sendo chamado toda vez que termina um dialogo
    //acho q vc tambem pode usar isso pra fazer mudar de ação doq ta fazendo
    public void EndingDialogo()
    {
        //sempre quando acaba um dialogo ele acrescenta um numero pra fazer a proxima coisa
        seqAcontecimento++;
        //desativa tambem a caixa do dialogo
        boxDialogue.SetActive(false);

        switch (seqAcontecimento)
        {
            case 1:

                //clicar na quest
                plantarDir.interactable = false;
                plantarEsq.interactable = false;
                plantarMeio.interactable = false;
                painelFerramenta.interactable = false;
                painelInventario.interactable = false;
                loja.interactable = false;
                quest.interactable = true;
                adubo.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(quest.transform.position.x, quest.transform.position.y-0.7f);
                dedoL.gameObject.SetActive(true);
                
                break;
            case 2:

                //clicar em aceitar
                plantarDir.interactable = false;
                plantarEsq.interactable = false;
                plantarMeio.interactable = true;
                painelFerramenta.interactable = false;
                quest.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(aceitarQuest.transform.position.x, aceitarQuest.transform.position.y-0.2f);
                dedoL.gameObject.SetActive(true);
                

                break;
            case 3:

                //clicar na terra
                plantarDir.interactable = false;
                plantarEsq.interactable = false;
                plantarMeio.interactable = true;
                painelFerramenta.interactable = false;
                quest.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(terraMeio.position.x, terraMeio.position.y);
                dedoL.gameObject.SetActive(true);
                

                break;
            case 4:

                //clicar em ferramentas
                plantar.terra.botao.RemoveListener(TriggerDialogos);
                ferramenta.interactable = true;
                planta.interactable = false;
                painelItem.interactable = false;


                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(ferramenta.transform.position.x, ferramenta.transform.position.y);
                dedoL.gameObject.SetActive(true);              

                break;
            case 5:

                painel.SetActive(true);
                fazendeiro.OnEndAction -= EndingDialogo;
                //Clicar na planta
                ferramenta.interactable = false;
                planta.interactable = true;
                painelSemente.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(planta.transform.position.x, planta.transform.position.y);
                dedoL.gameObject.SetActive(true);

                

                break;
            case 6:


                ferramenta.interactable = false;
                planta.interactable = true;
                painelSemente.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(itemDisplay.transform.position.x, itemDisplay.transform.position.y);
                dedoL.gameObject.SetActive(true);


                break;
            case 7:
                //ele peguar a recompesa

                inventario.interactable = false;

                dedoL.gameObject.SetActive(false);
                boxDialogue.SetActive(true);
                triggers[2].TriggerDialogue();

               
                break;
            case 8:
                //liberar o repolho

                StartCoroutine(SegundaFase());

               
                break;

            case 9:

                inventario.interactable = true;
                itemDisplay.OnFeedBack -= EndingDialogo;
                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(itemDisplay.transform.position.x, itemDisplay.transform.position.y);
                dedoL.gameObject.SetActive(true);

                break;

            case 10:

                plantar.player.OnColherItens -= COLHA;
                painel.SetActive(false);
                quest.interactable = true;
                painelInventario.interactable = true;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(quest.transform.position.x, quest.transform.position.y);
                dedoL.gameObject.SetActive(true);
                break;

            case 11:

                quest.interactable = false;
                painelItem.gameObject.SetActive(false);
                loja.interactable = false;
                painelInventario.interactable = true;
                plantarDir.interactable = false;
                plantarEsq.interactable = false;
                plantarMeio.interactable = false;
                painelItem.interactable = false;


                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(painelInventario.transform.position.x+0.5f, painelInventario.transform.position.y-1f);
                dedoL.gameObject.SetActive(true);
                break;
            case 12:

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(itemLiberado.transform.position.x +2.7f, itemLiberado.transform.position.y+3f);
                dedoL.gameObject.SetActive(true);


                break;

            case 13:

                painelItem.gameObject.SetActive(false);
                quest.interactable = false;
                loja.interactable = true;
                painelInventario.interactable = false;

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(loja.transform.position.x+1f, loja.transform.position.y-1f);
                dedoL.gameObject.SetActive(true);
                break;

            case 14:
  
                compraAlface.interactable = false;
                painelLoja.interactable = false;
                painelCompra.interactable = false;
                melhorias.interactable = false;
                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(compraRepolho.transform.position.x-2.7f, compraRepolho.transform.position.y );
                dedoL.gameObject.SetActive(true);
               
                break;

            case 15:

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(mais.transform.position.x +5.2f, mais.transform.position.y );
                dedoL.gameObject.SetActive(true);
                break;

            case 16:

                dedoL.gameObject.SetActive(false);
                dedoL.TrocaPos(compra.transform.position.x , compra.transform.position.y -0.3f);
                dedoL.gameObject.SetActive(true);
                break;
            case 17:
                SceneManager.LoadScene(start);
                break;


        }
    }

    //pode ser triggado usando qq coisa pra ativar os proximos dialogos
     public void TriggerDialogos()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            if (i == seqAcontecimento-2)
            {
                //ativa o proximo dialogo
                dedoL.gameObject.SetActive(false);
                boxDialogue.SetActive(true);
                triggers[i].TriggerDialogue();
                   
            }
        }
    }
    public IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        trigger1.TriggerDialogue();
    }
    public IEnumerator SegundaFase()
    {
        painelItem.gameObject.SetActive(false);
        plantarMeio.interactable = false;


        dedoL.gameObject.SetActive(false);
        dedoL.TrocaPos(vida.transform.position.x, vida.transform.position.y);
        dedoL.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        dedoL.gameObject.SetActive(false);
        boxDialogue.SetActive(true);
        triggers[3].TriggerDialogue();

    }

    void COLHA(Item ite, int a)
    {
        dedoL.gameObject.SetActive(false);
        boxDialogue.SetActive(true);
        triggers[4].TriggerDialogue();
    }

    public void Receber()
    {
        if(seqAcontecimento == 10)
        {
            dedoL.gameObject.SetActive(false);
            dedoL.TrocaPos(receber.transform.position.x, receber.transform.position.y-0.3f);
            dedoL.gameObject.SetActive(true);
        }
    }

    public void Liberado()
    {
        dedoL.gameObject.SetActive(false);
        boxDialogue.SetActive(true);
        triggers[5].TriggerDialogue();
    }

    public void Loja()
    {
        dedoL.gameObject.SetActive(false);
        boxDialogue.SetActive(true);
        triggers[6].TriggerDialogue();
    }

    public void Final()
    {
        dedoL.gameObject.SetActive(false);
        boxDialogue.SetActive(true);
        triggers[7].TriggerDialogue();

    }
}

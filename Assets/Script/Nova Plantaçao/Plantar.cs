using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plantar : MonoBehaviour
{
    public Fazendeiro fazendeiro;
    private bool vaiColer;
    int pontosTotais;
    [HideInInspector]
    public float tempo;
    public Terra terra;
    public ItensDeFazenda itensDeFazenda;
    public Vida vida;
    public Combo combo;
    public Placa placa;
    public ItemDisplay[] itensDisplay;
    

    private Item plantaEscolhida;
    private int quantidadePlantada;
    public Player player;

    public ParticleSystem moedas;
    public ParticleSystem errou;

    public Image image;
    private bool podeColher;
    public FeedbackNmb feedbackNmb;
    public FeedBackPlantar feedBackPlantar;

    private bool click;
    private int vidaAoPlantar;
    private void Start()
    {
        for (int i = 0; i < itensDisplay.Length; i++)
        {
            itensDisplay[i].OnPlantar += Plantando;
        }
        terra.fazendeiro.OnEndAction += Colher;
        terra.fazendeiro.OnEndAction += Planta;

    }

    private void Update()
    {
        EsperaNascer();

        //SEGUNDO: vejo se foi clicado e o cara ta ocupado, se nao tiver ele roda oq era pra fazer antes
        if(click && !fazendeiro.ocupado && terra.index == fazendeiro.sequencia[0])
        {
            Teste();
        }
    }

    public void Plantando(Item item, int quantidade)
    {
        //PRIMEIRO: igualo as variaveis importantes e aviso que foi chamado o metodo com o click
        plantaEscolhida = item;
        quantidadePlantada = quantidade;
        click = true;
        vidaAoPlantar = vida.currentHealth;
        player.OnSobrevida?.Invoke(vida.currentHealth);
        terra.QuantidadeEmitida(item.tipoDaPlanta, vida.currentHealth);

    }

    //TERCEIRO: roda as coisas de antes só depois do cara plantar
    void Teste()
    {
        if (terra.estadosDaTerra == EstadosDaTerra.SOIL)
        {
            StartCoroutine(FeedBacksCoracao(plantaEscolhida, true));
        }
        else
        {
            StartCoroutine(FeedBacksCoracao(plantaEscolhida, false));
        }

        placa.algo?.Invoke(plantaEscolhida.nomeDaPlanta, plantaEscolhida.sprite, plantaEscolhida.tipoDaPlanta);

        player.OnPlantar?.Invoke(plantaEscolhida.nomeDaPlanta, quantidadePlantada);

        if (player.quest != null)
            player.quest.CheckGoals();

        combo.combo?.Invoke(plantaEscolhida);
        feedBackPlantar.ResetaFeedback();
        click = false;
    }



    public void Planta()
    {
        if (plantaEscolhida != null) { 
            if (itensDeFazenda.itens == TipoDeFerramenta.PLANTAR)
            {
                //terra.sprite.sprite = plantaEscolhida.plantarSprite;

                //for (int i = 0; i < terra.spriteMulti.Length; i++)
                //{
                //    if (i + 2 <= quantidadePlantada)
                //        terra.spriteMulti[i].sprite = plantaEscolhida.plantarSprite;
                //}
                for (int i = 0; i < feedBackPlantar.sprites.Length; i++)
                {
                    Color color = feedBackPlantar.sprites[i].color;
                    color.a = 1f;
                    feedBackPlantar.sprites[i].color = color;
                }
                itensDeFazenda.itens = TipoDeFerramenta.Plantado;
                pontosTotais = plantaEscolhida.ponto;
                tempo = plantaEscolhida.tempoParaCrescer;
                terra.estadosDaTerra = EstadosDaTerra.PLANTAR;
                vaiColer = true;
            }

        }
    }

    void EsperaNascer()
    {
        
        if (plantaEscolhida != null)
        {
            if (tempo <= 0  && itensDeFazenda.itens == TipoDeFerramenta.Plantado)
            {
                //terra.sprite.sprite = plantaEscolhida.crescidaSprite;

                //for (int i = 0; i < terra.spriteMulti.Length; i++)
                //{
                //    if (i + 2 <= quantidadePlantada)
                //        terra.spriteMulti[i].sprite = plantaEscolhida.crescidaSprite;
                //}
               
                vaiColer = false;
               

                //se ele nao tiver ocupado, chama pra colher
                if (!fazendeiro.ocupado)
                {
                    podeColher = true;
                    tempo = plantaEscolhida.tempoParaCrescer;
                    itensDeFazenda.click?.Invoke(TipoDeFerramenta.Plantado);
                }

               
            }
            else if (vaiColer)
            {
                feedBackPlantar.tem = plantaEscolhida.tempoParaCrescer;
                image.fillAmount = tempo/plantaEscolhida.tempoParaCrescer;
                tempo -= Time.deltaTime;
                feedBackPlantar.MudarSprite();
            }
        }
    }
    void Colher()
    {
        if (podeColher)
        {
            //reseta o solo
            terra.estadosDaTerra = EstadosDaTerra.SOIL;

            //faz conseguir clicar novamente
            itensDeFazenda.controle = false;

            //reseta os itens
            itensDeFazenda.itens = TipoDeFerramenta.TERRA;

            //toca a particula de moeda
            //moedas.Play();

            //mostra que colheu o item

            player.OnColherItens?.Invoke(plantaEscolhida, quantidadePlantada);

            //reseta o solo
            plantaEscolhida = null;

            //checa para ver se uma quest terminou
            if (player.quest != null)
                player.quest.CheckGoals();


            //adiciona os pontos
            vida.soma(pontosTotais, vidaAoPlantar);

            //reseta os pontos
            pontosTotais = 0;

            //reseta as plantas 
            feedBackPlantar.Desativar();
            //animaçao de recuperar vida
            feedbackNmb.number = 1;
            feedbackNmb.feedback = "Vida";
            feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
            feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
            vida.SetHealth(false, 1);
            podeColher = false;

        }

    }

    IEnumerator FeedBacksCoracao(Item itemt, bool again)
    {
        if (again)
        {
            //Nao arou
            feedbackNmb.tipo = TipoFeed.Vida;
            feedbackNmb.number = -1;
            feedbackNmb.feedback = "Arar";
            feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y+2f, vida.transform.position.z);
            feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
            vida.SetHealth(true, 1);
        }
        else
        {
            //Arou Certinho, Vida que a planta consome
            feedbackNmb.tipo = TipoFeed.Vida;
            feedbackNmb.number = -itemt.vidaConsumida;
            feedbackNmb.feedback = "Vida";
            feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
            feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
            vida.SetHealth(true, itemt.vidaConsumida);
        }

        yield return new WaitForSeconds(feedbackNmb.duration+0.3f);

        if (again)
        {

            //Naoarou, Vida que a planta consome
            feedbackNmb.tipo = TipoFeed.Vida;
            feedbackNmb.number = -itemt.vidaConsumida;
            feedbackNmb.feedback = "Vida";
            feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
            feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
            vida.SetHealth(true, itemt.vidaConsumida);
        }
        else
        {
            //Arou certinho, verifica o combo
            if (combo.begin)
            {
                if (combo.fail)
                {
                    //plantou a msm planta
                    feedbackNmb.tipo = TipoFeed.Vida;
                    feedbackNmb.number = -1;
                    feedbackNmb.feedback = "Rotação";
                    feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
                    feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
                    
                    vida.SetHealth(true, 1);
                }
                else
                {
                    //diversificou a planta
                    feedbackNmb.tipo = TipoFeed.Vida;
                    feedbackNmb.number = +2;
                    feedbackNmb.feedback = "Rotação";
                    feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
                    feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
                    vida.SetHealth(false, 2);
                }
            }
           
        }

        yield return new WaitForSeconds(feedbackNmb.duration+0.3f);

        if (again)
        {
            //Arou certinho, verifica o combo
            if (combo.begin)
            {
                if (combo.fail)
                {
                    //plantou a msm planta
                    feedbackNmb.tipo = TipoFeed.Vida;
                    feedbackNmb.number = -1;
                    feedbackNmb.feedback = "Rotação";
                    feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
                    feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
                    vida.SetHealth(true, 1);
                }
                else
                {
                    //diversificou a planta
                    feedbackNmb.tipo = TipoFeed.Vida;
                    feedbackNmb.number = +2;
                    feedbackNmb.feedback = "Rotação";
                    feedbackNmb.targetInicial.position = new Vector3(vida.transform.position.x, vida.transform.position.y + 2f, vida.transform.position.z);
                    feedbackNmb.numeroGO.transform.parent.gameObject.SetActive(true);
                    vida.SetHealth(false, 2);
                }
            }
            
        }
        else
        {

        }
    }
}

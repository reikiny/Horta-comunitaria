using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenItens : MonoBehaviour
{
    public static string Gardenitens = "None";

//    public estadosDaTerra estadosDa;
//    int pontosParaguadar;
//    float tempoParaguadar;

//    public static ItemDisplay itemDisplay;
//    ItensDeFazenda itensDe;
//    public float timerDoIenumereitor;

//    Farms farm;
//    GameObject farmer;
//    private void Update()
//    {
//        PegarInformacoes();
//    }
//    public void PegarInformacoes()
//    {
//        if (itemDisplay != null)
//        {
//            if (estadosDa == estadosDaTerra.ADUBAR)
//            {
//                GetComponent<SpriteRenderer>().sprite = itemDisplay.item.plantarSprite;
//                tempoParaguadar = itemDisplay.item.TempoParaCrescer;
//                estadosDa = estadosDaTerra.REGAR;
//            }

//            if (estadosDa == estadosDaTerra.PLANTAR)
//            {
//                if (itemDisplay.item.TempoParaCrescer <= 0 && estadosDa == estadosDaTerra.PLANTAR)
//                {
                   
//                    GetComponent<SpriteRenderer>().sprite = itemDisplay.item.crescidaSprite;
//                    pontosParaguadar = itemDisplay.item.Ponto;
//                    itemDisplay.item.TempoParaCrescer = tempoParaguadar;
//                    estadosDa = estadosDaTerra.PODECOLER;
//                    itemDisplay = null;

//                }
//                else
//                {
//                    itemDisplay.item.TempoParaCrescer -= Time.deltaTime;
//                }
//            }
//        }
        
//    }

   
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (estadosDa == estadosDaTerra.PODECOLER && collision.CompareTag("Farms") && itemDisplay == null)
//        {
//            farmer = collision.gameObject;
//            farm = farmer.GetComponent<Farms>();
//            Pontos.scoreNumber += pontosParaguadar;
//            StartCoroutine(harvest());
//        }
//    }
//    IEnumerator harvest()
//    {
//        farm.speed = 0;
//        yield return new WaitForSeconds(timerDoIenumereitor);

//        farm.speed = 50;
//        estadosDa = estadosDaTerra.SOIL;

//    }
}


using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public Vector3 target;
    public Vector3 target2;
    public float duration;
    public Ease ease;
    public GameObject[] bestiario;
    public Transform toldo, lado;

   public void Animar()
    {
        objeto1.transform.DOMove(target, duration).SetEase(ease).SetRecyclable(true);
    }

    public void Bestiario()
    {
        for (int i = 0; i < bestiario.Length; i++)
        {
            bestiario[i].transform.DOScale(target, duration + (float)i / 20).From().SetEase(ease).OnComplete(() => StartCoroutine(Espera()));

        }

    }   
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < bestiario.Length; i++)
        {
                bestiario[i].transform.DOScale(1, 0);
        }
    }

    public void Escalar()
    {
        objeto1.transform.DOScale(0, duration).From().SetEase(ease);
    }

    public void Toldo()
    {
        objeto2.transform.DOMove(target2, duration).SetEase(ease);
       // Botao.transform.DOMove(target2, duration).SetEase(ease).SetRecyclable(true);
    }

    public void EscalaEMove()
    {
       

        Vector3 targetoit = new Vector3(lado.position.x, lado.position.y, target2.z);

        objeto2.transform.DOMove(targetoit, duration).SetEase(ease);

        Vector3 targeto = new Vector3(toldo.position.x, toldo.position.y, target2.z);
        //toldo
        objeto3.transform.DOMove(targeto, duration).SetEase(ease);        
    }

    void Volta()
    {
        objeto2.transform.DOMove(target, duration).SetEase(ease);
        objeto3.transform.DOMove(target2, duration).SetEase(ease);
    }

   public void Rotacao(GameObject gO)
    {
        
        gO.transform.DORotate(target, duration).SetLoops(4,LoopType.Incremental);
    }

    public void FecharLoja()
    {
        objeto1.transform.DOScale(0, duration).OnComplete(()=> StartCoroutine(Fecha()));
    }

    IEnumerator Fecha()
    {
        objeto1.transform.parent.gameObject.SetActive(false);
        objeto1.transform.DOScale(1, 0);
        Volta();
        yield return new WaitForSeconds(0.1f);
    }
}

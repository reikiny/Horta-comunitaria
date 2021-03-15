using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoFeed { Pontos, Vida}
public class FeedbackNmb : MonoBehaviour
{
    public GameObject numeroGO, terrinha;
    public float number;
    public float duration;
    public Ease ease;
    public Transform targetCima, targetBaixo, targetInicial;
    public Text texto;
    private Tween myTween;
    public string feedback;
    public TipoFeed tipo;
    public Color vermelho;
    public Color verde;

    private void OnEnable()
    {

        gameObject.transform.position = targetInicial.position;


        numeroGO.transform.DOMove(targetInicial.position, 0);
        numeroGO.GetComponent<Image>().DOFade(1, 0);
        texto.DOFade(1, 0);
        if (tipo == TipoFeed.Vida)
            terrinha.GetComponent<Image>().DOFade(1, 0);

            if (number > 0)
        {
            Acerto();
        }

        else if (number < 0)
        {
            Erro();
        }
        
    }

    public void Acerto()
    {
        Sequence mysequence = DOTween.Sequence();
        myTween = numeroGO.transform.DOMove(targetCima.position, duration);
        texto.text = "+" + number + " " + feedback;

        if (tipo == TipoFeed.Vida)
        {
            numeroGO.GetComponent<Image>().color = Color.green;
            texto.color = Color.green;
            mysequence.Append(myTween.SetEase(ease).SetRecyclable(true))
            .Insert(0.2f, numeroGO.GetComponent<Image>().DOFade(0, duration))
            .Insert(0.2f, texto.DOFade(0, duration))
            .Insert(0.2f, terrinha.GetComponent<Image>().DOFade(0, duration))
            .OnStepComplete(() => gameObject.SetActive(false));

        }else
        {
            numeroGO.GetComponent<Image>().color = Color.white;
            texto.color = Color.black;
            mysequence.Append(myTween.SetEase(ease).SetRecyclable(true))
    .Insert(0.2f, numeroGO.GetComponent<Image>().DOFade(0, duration))
    .Insert(0.2f, texto.DOFade(0, duration))
    .OnStepComplete(() => gameObject.SetActive(false));
        }

        


    }

    public void Erro()
    {
        Sequence mysequence = DOTween.Sequence();
        myTween = numeroGO.transform.DOMove(targetBaixo.position, duration);
        texto.text = number + " " + feedback;

        if (tipo == TipoFeed.Vida)
        {
            numeroGO.GetComponent<Image>().color = Color.red;
            mysequence.Append(myTween.SetEase(ease).SetRecyclable(true))
                .Insert(0.2f, numeroGO.GetComponent<Image>().DOFade(0, duration))
                .Insert(0.2f, texto.DOFade(0, duration))
                .Insert(0.2f, terrinha.GetComponent<Image>().DOFade(0, duration))
                .OnStepComplete(() => gameObject.SetActive(false));

            texto.color = Color.red;
        }
        else
        {
            numeroGO.GetComponent<Image>().color = Color.white;
            texto.color = Color.black;
            mysequence.Append(myTween.SetEase(ease).SetRecyclable(true))
                .Insert(0.2f, numeroGO.GetComponent<Image>().DOFade(0, duration))
                .Insert(0.2f, texto.DOFade(0, duration))
                .OnStepComplete(() => gameObject.SetActive(false));
        }


          
            
    }

}

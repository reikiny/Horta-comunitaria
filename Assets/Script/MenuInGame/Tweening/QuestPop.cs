using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPop : MonoBehaviour
{
    public float duration;
    public Ease ease;
    private Tween myTween;
    public Color vermelho;
    public Color amarelo;
    public Color cinza;
    public Image image;
    private Color cor;
    bool loop;
    public bool interroga;
    private void OnEnable()
    {
        PegarQuest();
        StartCoroutine(Vermelho());
    }
    public void PegarQuest()
    {
        //image.color = Color.white;
        if (interroga)
        {
            ColsultarQuest();
        }
           
        else
        {
            cor = vermelho;
            loop = true;
        }
           

    }
    public void ColsultarQuest()
    {
        //image.color = Color.white;
        loop = false;
        cor = cinza;
        
        
    }
    public void QuestPronta()
    {
        
        cor = amarelo;
        loop = true;
    }
   
    IEnumerator Vermelho()
    {
        while (true)
        {
            
            if(loop)
                myTween = image.DOColor(cor, duration).SetLoops(2, LoopType.Yoyo);
            else
            {
                myTween.SetLoops(0);
                image.color = cor;
            }
            yield return new WaitForSeconds(duration * 2);
        }
    }
}

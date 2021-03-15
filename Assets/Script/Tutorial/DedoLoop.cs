using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedoLoop : MonoBehaviour
{
    public GameObject dedo;
    public Transform target;
    public float duration;
    public Ease ease;
    Tween tween;

    private void OnEnable()
    {
        StartCoroutine(DOthing());
      
    }
    public void TrocaPos(float x,float y)
    {

        tween.SetLoops(0);
        tween.Complete();
        this.transform.position = new Vector3(x, y, this.transform.position.z);
        target.position = gameObject.transform.position;
        dedo.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-0.3f, this.transform.position.z);


    }
    private IEnumerator DOthing()
    {
        while (true)
        {
            Vector3 vetor = new Vector3(dedo.transform.position.x, target.position.y, dedo.transform.position.z);
            tween = dedo.transform.DOMove(vetor, duration).SetLoops(2, LoopType.Yoyo).SetEase(ease).SetRecyclable(true);
            yield return new WaitForSeconds(duration*2);
        }
       

    }



}

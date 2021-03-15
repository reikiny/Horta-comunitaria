using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batata : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(SlowUpdate());
    }

   
    void Update()
    {
        
    }
    IEnumerator SlowUpdate()
    {
        while (true)
        {
            
            Tick();
            yield return new WaitForSeconds(5f);

        }
    }

    void Tick()
    {
        Debug.Log("Tick");
    }
}

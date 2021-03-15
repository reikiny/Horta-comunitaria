//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class Agua : MonoBehaviour
//{
//    public Slider slider;
//    public int currentWater;
//    private int maxWater = 6;
//    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
//    private Coroutine regen;




//    private void Start()
//    {
//        currentWater = maxWater;
//        slider.maxValue = maxWater;
//        slider.value = maxWater;

//    }

//    public void SetAgua(int quantidade)
//    {

//        currentWater -= quantidade;
//        slider.value = currentWater;
//        if (regen != null)
//            StopCoroutine(regen);

//        regen = StartCoroutine(RegenHealth());


//    }
//    public IEnumerator RegenHealth()
//    {
//        yield return new WaitForSeconds(10);
//        while (currentWater < maxWater)
//        {
//            currentWater += 1;
//            slider.value = currentWater;
//            yield return new WaitForSeconds(10);
//        }
//        regen = null;
//    }

//}

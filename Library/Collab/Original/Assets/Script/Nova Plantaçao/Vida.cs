using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Vida : MonoBehaviour
{
    public Slider slider;
    public int currentHealth;
    private int maxHealth = 6;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public Action<int> barraVida;
    [HideInInspector]
    

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        barraVida += setHealth;
    }
    
    public void setHealth(int quantidade)
    {

            currentHealth -= quantidade;
            slider.value = currentHealth;
            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenHealth());


    }
    public IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(10);
        while(currentHealth < maxHealth)
        {
            currentHealth += 1;
            slider.value = currentHealth;
            yield return new WaitForSeconds(10);
        }
        regen = null;
    }

}

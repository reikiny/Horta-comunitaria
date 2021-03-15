using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum EstadosDaVida {SobreVida,VidaNormal,VidaCritica }
public class Vida : MonoBehaviour
{
    public EstadosDaVida estadosDaVida;
    public Slider slider;
    public Image image;
    public Image coracao;
    public Text text;
    public int currentHealth = 8;
    public int maxHealth = 8;

    public ParticleSystem moedas;

    public Action<int,int> soma;
    public Action<int, int> modificarVida;

    public AudioSource source;
    public AudioClip sobe;
    public AudioClip desce;
    public AudioClip cash;
    private void Start()
    {
        soma += Dividindo;
        modificarVida += Heath;
        
    }
    private void Update()
    {
        text.text = (currentHealth + " /  " + slider.maxValue);
        Vidas();
        Heath(maxHealth, currentHealth);
    }

    void Heath(int maxHealth,int currentHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }


    public void SetHealth(bool mudar,int quantidade)
    {
        
        if (mudar)
        {
            if (currentHealth + quantidade < 0)
                currentHealth = 0;
            else if(currentHealth + quantidade >= 0)
                currentHealth -= quantidade;
            source.PlayOneShot(desce);
            slider.value = currentHealth;
        }
        else if (!mudar)
        {
            if(quantidade+currentHealth > maxHealth)
                currentHealth = maxHealth;
            else if(quantidade+currentHealth <= maxHealth)
                currentHealth += quantidade;
            source.PlayOneShot(sobe);
            slider.value = currentHealth;
        }
    }

    public void Vidas()
    {
        if (currentHealth >= 7)
        { 
            estadosDaVida = EstadosDaVida.SobreVida;
            image.color = Color.green;
            coracao.color = Color.green;
        }
        if (currentHealth == 4 || currentHealth == 5 || currentHealth == 6)
        {
            estadosDaVida = EstadosDaVida.VidaNormal;
            image.color = Color.yellow;
            coracao.color = Color.yellow;
        }
        if (currentHealth == 1 || currentHealth == 2 || currentHealth == 3)
        {
            estadosDaVida = EstadosDaVida.VidaCritica;
            image.color = Color.red;
            coracao.color = Color.red;
        }
    }

    public void Dividindo(int multi, int vidaAoPlantar)
    {
        var emission = moedas.emission;

        if (vidaAoPlantar >= 7)
        {
            Pontos.scoreNumber += multi * 2;
            //altaVida.Play();
            emission.rateOverTime = 20;
        }
        if (vidaAoPlantar == 4 || vidaAoPlantar == 5 || vidaAoPlantar == 6)
        {
            //meioVida.Play();
            Pontos.scoreNumber += multi;
            emission.rateOverTime = 10;
        }
        if (vidaAoPlantar == 1 || vidaAoPlantar == 2 || vidaAoPlantar == 3)
        {
            //poucaVida.Play();
            Pontos.scoreNumber += multi / 2;
            emission.rateOverTime = 3;
        }        
        moedas.Play();
        source.PlayOneShot(cash);
    }
}

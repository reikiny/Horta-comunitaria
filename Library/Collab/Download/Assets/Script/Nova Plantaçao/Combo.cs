using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Combo : MonoBehaviour
{
    public List<TipoDePlanta> combos;
    public Vida vida;
    public ParticleSystem acertou;
    public ParticleSystem errou;
    public  int limite;
    public bool iniciar;

    public Player player;

    public Action<TipoDePlanta> combo;

    private void Start()
    {
        combo += EstadoDoCombo;
        StartCoroutine(SlowUpdate());
     
    }
    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            teste();
        }
    }
    void EstadoDoCombo(TipoDePlanta planta)
    {
        if (limite <= 2 && !iniciar)
        {
            combos.Add(planta);
            limite++;
        }
    } 
    void teste()
    {
        
        if (limite == 2)
        {
            iniciar = true;
        }
        if (iniciar)
        {
            for (int i = 0; i < combos.Count; i++)
            {
                if (combos[0] == combos[1])
                {
                    
                    errou.Play();
                    Debug.Log("Errou");
                    vida.SetHealth(true, 1);
                    combos.RemoveAt(0);
                    iniciar = false;
                    limite = 1;
                }
               else if (combos[0] != combos[1])
                {
                   
                    acertou.Play();
                    vida.SetHealth(false, 2);
                    Debug.Log("Acertou");
                    combos.RemoveAt(0);
                    iniciar = false;
                    limite = 1;
                }
            }
        } 
    }
        
    
}

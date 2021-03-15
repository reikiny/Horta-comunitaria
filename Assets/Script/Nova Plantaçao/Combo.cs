using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Combo : MonoBehaviour
{
    public List<Item> combos;
    public Vida vida;
    public ParticleSystem acertou;
    public ParticleSystem errou;
    public  int limite;
    public bool iniciar;
    public bool begin;
    public bool fail;
    public Player player;

    public Action<Item> combo;

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
            Teste();
        }
    }
    void EstadoDoCombo(Item planta)
    {
        if (limite <= 2 && !iniciar)
        {
            combos.Add(planta);
            limite++;
        }
    } 
    void Teste()
    {
        
        if (limite == 2)
        {
            iniciar = true;
            begin = true;
        }
        if (iniciar)
        {
            for (int i = 0; i < combos.Count; i++)
            {
                if (combos[0] == combos[1])
                {
                    
                    //errou.Play();
                    //Debug.Log("Errou");
                    //vida.SetHealth(true, 1);
                    combos.RemoveAt(0);
                    fail = true;
                    iniciar = false;
                    limite = 1;
                   
                }
               else if (combos[0] != combos[1])
                {
                   
                    //acertou.Play();
                    //vida.SetHealth(false, 2);
                    //Debug.Log("Acertou");
                    combos.RemoveAt(0);
                    fail = false;
                    iniciar = false;
                    limite = 1;
                    player.OnRotacao?.Invoke();
                    
                }
            }
        } 
    }
        
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MyEnum
{
    Nada,
    Acertou,
    Errou
}
public class Combo : MonoBehaviour
{
    public MyEnum myEnum;
    public NomeDaPlanta nomeDaPlanta;
    public List<TipoDePlanta> combos;
    public Terra terra;
    public Vida vida;
    public Placa placa;
    public ParticleSystem acertou;
    public ParticleSystem errou;
    public int limite { get; set; }
    private bool iniciar;

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
            iniciar = false;
            limite = 0;
            int conta = combos.Count;
            for (int i = 0; i < conta; i++)
            {
                if (combos[0] == combos[1])
                {
                    myEnum = MyEnum.Errou; 
                    myEnum = MyEnum.Errou; 
                }
               if (combos[0] != combos[1])
                {
                    myEnum = MyEnum.Acertou;
                }
              
            }
            combos.Clear();

            if (myEnum == MyEnum.Errou)
            {
                errou.Play();
                vida.SetHealth(true, 1);
                placa.nomePlanta = NomeDaPlanta.Nada;
                myEnum = MyEnum.Nada;
            }
            else if (myEnum == MyEnum.Acertou)
            {
                acertou.Play();
                vida.SetHealth(false, 2);
                placa.nomePlanta = NomeDaPlanta.Nada;
                myEnum = MyEnum.Nada;
            }
        } 
    }
        
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Quest quest;
    public Action<Item,int> OnColherItens;
    public Action<NomeDaPlanta,int> OnPlantar;
    public Action<int> OnSobrevida;
    public Action <Item> OnLiberarItem;
    public Action OnRotacao;

    
}

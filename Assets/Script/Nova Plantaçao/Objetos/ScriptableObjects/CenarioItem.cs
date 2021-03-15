using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoCenarioItem { Xavier, Chico, Plantinhas, Animais, PANC1, PANC2, Cisterna, Gotejamento}

[CreateAssetMenu(fileName = "Novo Upgrade", menuName = "Item/Cenario")]
public class CenarioItem : ScriptableObject
{
    public TipoCenarioItem tipoCenarioItem;
    public int preco;
    

    [TextArea]
    public string descricao;
    [TextArea]
    public string melhoria;

    public Sprite spriteLoja;
    public bool Usado;
    public int paraSave;

}

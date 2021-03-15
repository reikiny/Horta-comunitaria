using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDeIrrigacao { Cisterna, GarrafaPet, Gotejamento}

[CreateAssetMenu(fileName = "Nova Irrigacao", menuName = "Item/Irrigacao")]
public class Irrigacao : ScriptableObject
{
    public TipoDeIrrigacao tipoDeIrrigacao;
    public int Preco;
    public int quantidadePossuida;

    [TextArea]
    public string descricao;

    public Sprite spriteLoja;
    public Sprite sprite;
    public bool liberada;

}

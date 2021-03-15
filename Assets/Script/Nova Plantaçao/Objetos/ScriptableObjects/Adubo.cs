using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDeAdubo { Cavalo, Galinha, Compostagem}

[CreateAssetMenu(fileName = "Novo Adubo", menuName = "Item/Adubo")]
public class Adubo : ScriptableObject
{
    public TipoDeAdubo tipoDoAdubo;
    public int quantidadePossuida;
    public int quantidaddeQueRecuperaAVida;
    public int preco;

    [TextArea]
    public string descricao;

    public Sprite sprite;
    public Sprite lockSprite;
    //public Sprite sprite;
    //public Sprite lockSprite;

   // public bool liberado;


}

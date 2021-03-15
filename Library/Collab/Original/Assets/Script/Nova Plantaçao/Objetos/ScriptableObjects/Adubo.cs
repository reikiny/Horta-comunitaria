using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoDeAdubo { Cavalo, Galinha, Compostagem}

[CreateAssetMenu(fileName = "Novo Adubo", menuName = "Item/Adubo")]
public class Adubo : ScriptableObject
{
    public TipoDeAdubo tipoDoAdubo;
    public float tempo;
    public int multiplicadorDePontos;
    public int quantidadePossuida;
    public int Preco;

    [TextArea]
    public string descricao;

    public Sprite spriteLoja;
    public Sprite sprite;
    public bool liberado;

}

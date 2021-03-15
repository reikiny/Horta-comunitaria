
using UnityEngine;

public enum NomeDaPlanta { ALFACE, REPOLHO, TOMATE, BATATADOCE, CENOURA, MANDIOCA, BANANA, MAMAO, LIMAO, PANC,};
public enum TipoDePlanta { Vegetais, Tuberculos, Frutiferas, Panc };

[CreateAssetMenu(fileName = "Nova Planta", menuName = "Item/Plantas")]
public class Item : ScriptableObject
{
    public NomeDaPlanta nomeDaPlanta;
    public TipoDePlanta tipoDaPlanta;

    public int quantidadePossuida;
    //public int quantiaEscolhida;
    public float tempoParaCrescer;
    public int ponto;
    public int preco;
    public int vidaConsumida;

    [TextArea]
    public string descricao;

    public Sprite sprite;
    public Sprite plantarSprite;
    public Sprite crescidaSprite;
    public Sprite lockSprite;
    public Sprite lojaSprite;
    public Sprite lojaBloqueadaSprite;

    public bool liberada;
}

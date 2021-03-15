
using UnityEngine;

public enum NomeDaPlanta { ALFACE, REPOLHO, TOMATE, BATATADOCE, CENOURA, MANDIOCA, BANANA, MAMAO, LIMAO, PANC,Nada};
public enum TipoDePlanta { Vegetais, Tuberculos, Frutiferas, Panc,Nada };

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

    //public string nome;
    [TextArea]
    public string descricao;
    [TextArea]
    public string bestiarioDes;
    public string cientifico;

    public Sprite sprite;
    public Sprite plantarSprite;
    public Sprite mudaSprite;
    public Sprite crescidaSprite;
    public Sprite lockSprite;
    public Sprite bestiarioSprite;
    public Sprite bestiarioLockSprite;


    public bool liberada;
}

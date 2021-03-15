//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TrocaCategorias : MonoBehaviour
//{
//    int categoria;
//    int max;
//    public Item[] vegetais;
//    public Item[] tuberculos;
//    public Item[] frutiferas;
//    public Item Panc;

//    public TrocaItens itensTroca;
//    private void Start()
//    {
        
//        for (int i = 0; i < vegetais.Length; i++)
//        {
//            itensTroca.itens[i] = vegetais[i];
//        }
//        max = 2;
//    }

//    public void TrocaMais() {
//        if (itensTroca.menu.tipoItem == TipoItem.Planta)
//        {
//            max = 2;
//        }
//        else
//        {
//            max = 0;
//        }

//        if (categoria<=max)
//        {
//            categoria++;

//        }
//        else
//        {
//            categoria = 0;
//        }
//        TrocadosItens();
//    }

//    public void TrocaMenos()
//    {
//        if (itensTroca.menu.tipoItem == TipoItem.Planta)
//        {
//            max = 2;
//        }
//        else
//        {
//            max = 0;
//        }

//        if (categoria > 0)
//        {
//            categoria--;

//        }
//        else
//        {
//            categoria = max+1;
//        }
//        TrocadosItens();
//    }

//    void TrocadosItens()
//    {
//        switch (categoria)
//        {
//            case 0:
//                if (itensTroca.menu.tipoItem == TipoItem.Planta)
//                {
//                    for (int i = 0; i < vegetais.Length; i++)
//                    {
//                        itensTroca.itens[i] = vegetais[i];
//                    }
                    
//                }
//                else
//                {
//                    itensTroca.menu.tipoItem = TipoItem.Irrigacao;
//                }
                 
//                break;
//            case 1:
//                if (itensTroca.menu.tipoItem == TipoItem.Planta)
//                {
//                    for (int i = 0; i < tuberculos.Length; i++)
//                    {
//                        itensTroca.itens[i] = tuberculos[i];
//                    }
                    
//                }
//                else
//                {
//                    itensTroca.menu.tipoItem = TipoItem.Adubo;
//                }
                 
//                break;
//            case 2:
//                if (itensTroca.menu.tipoItem == TipoItem.Planta)
//                {
//                    for (int i = 0; i < frutiferas.Length; i++)
//                    {
//                        itensTroca.itens[i] = frutiferas[i];
//                    }
                    
//                }
//                else
//                {

//                }
                 
//                break;
//            case 3:
//                if (itensTroca.menu.tipoItem == TipoItem.Planta)
//                {

//                    for (int i = 0; i < vegetais.Length; i++)
//                    {
//                        itensTroca.itens[i] = Panc;
//                    }
                    
//                }
//                else
//                {

//                }
//                break;

//        }
//    }
//    public void CategoriaPlanta()
//    {
//        itensTroca.menu.tipoItem = TipoItem.Planta;
//    }
//    public void CategoriaAdubo()
//    {
//        itensTroca.menu.tipoItem = TipoItem.Adubo;
//    }
//}

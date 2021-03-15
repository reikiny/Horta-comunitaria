//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class TrocaImagens : MonoBehaviour
//    //, IPointerDownHandler, IPointerUpHandler
    
//{
//    //public Vector2 startTouchposition, endTouchposition;
//    //public int contadorParaMudarImg;
//    //public Camera gameCamera;
//    public Image img;
//    public MenuPlantas menuItem;
//    public GameObject descricao, nome;
//    public bool ativar;

//    void Update()
//    {
//        if (!ativar)
//        {
//            if (menuItem.tipoItem == TipoItem.Planta)
//            {
//                if(menuItem.itemMostrado.liberada)
//                    img.sprite = menuItem.itemMostrado.crescidaSprite;
//                else
//                    img.sprite = menuItem.itemMostrado.lojaBloqueadaSprite;
//            }
//            else if (menuItem.tipoItem == TipoItem.Adubo)
//            {
//                if(menuItem.aduboMostrado.liberado)
//                    img.sprite = menuItem.aduboMostrado.spriteLoja;
//                else
//                    img.sprite = menuItem.aduboMostrado.spriteLojaBlock; 
//            }
//            else if (menuItem.tipoItem == TipoItem.Irrigacao)
//            {
//                if (menuItem.irrigacao.liberada)
//                    img.sprite = menuItem.irrigacao.spriteLoja;
//                else
//                    img.sprite = menuItem.irrigacao.spriteLojaBlock;           
//            }

//            descricao.SetActive(false);
//            nome.SetActive(false);
//        }
//        else
//        {
//            img.sprite = null;
//            descricao.SetActive(true);
//            nome.SetActive(true);
//        }
//        //switch (contadorParaMudarImg)
//        //{
//        //    case 0:
//        //        img.sprite = null;
//        //        texto.SetActive(true);
//        //        break;
//        //    case 1:
//        //        if (menuItem.tipoItem == TipoItem.Planta)
//        //        {
//        //            img.sprite = menuItem.itemMostrado.crescidaSprite;
//        //        }else if (menuItem.tipoItem == TipoItem.Adubo)
//        //        {
//        //            img.sprite = menuItem.aduboMostrado.spriteLoja;
//        //        }
//        //        else if (menuItem.tipoItem == TipoItem.Irrigacao)
//        //        {
//        //            img.sprite = menuItem.irrigacao.spriteLoja;
//        //        }
                
//        //        texto.SetActive(false);
//        //        break;
//            //case 2:
//            //    if (menuItem.tipoItem == TipoItem.Planta)
//            //    {
//            //        img.sprite = menuItem.itemMostrado.lojaSprite;
//            //    }
//            //    else if (menuItem.tipoItem == TipoItem.Adubo)
//            //    {
//            //        img.sprite = menuItem.aduboMostrado.spriteLoja;
//            //    }
//            //    else if (menuItem.tipoItem == TipoItem.Irrigacao)
//            //    {
//            //        img.sprite = menuItem.irrigacao.spriteLoja;
//            //    }
//            //    texto.SetActive(false);
//            //    break;
//        //}
       

//    }


//    public void MudarImagem()
//    {
//        ativar = !ativar;
//        //if (endTouchposition.x - startTouchposition.x > 0)
//        //{
//        //    if (contadorParaMudarImg <= 1)
//        //    {
//        //        contadorParaMudarImg++;
//        //    }
//        //    else
//        //    {
//        //        contadorParaMudarImg = 0;
//        //    }

//        //}
//        //else if (endTouchposition.x - startTouchposition.x < 0)
//        //{
//        //    if (contadorParaMudarImg > 0)
//        //    {
//        //        contadorParaMudarImg--;
//        //    }
//        //    else
//        //    {
//        //        contadorParaMudarImg = 2;
//        //    }

//        //}


//    }


//    //public void OnPointerDown(PointerEventData eventData)
//    //{
//    //    startTouchposition = gameCamera.ScreenToViewportPoint(eventData.position);
        
   
//    //}

//    //public void OnPointerUp(PointerEventData eventData)
//    //{
//    //    endTouchposition = gameCamera.ScreenToViewportPoint(eventData.position);
//    //    MudarImagem();
//    //}


//}

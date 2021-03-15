//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ArvoreDeTalentos : MonoBehaviour
//{
//    public Button[] Upgrade;
//    public int[] PontosNecessarios;
//    public bool[] JaUsou;

//    public Upgrades[] upgradesScripts;
//    public Image barrinha;
//    float valorFill;

//    void Start()
//    {

//        for (int i = 0; i < Upgrade.Length; i++)
//        {
//            if (i == 0)
//            {
//                Upgrade[i].interactable = true;
//            }
//            else
//            {
//                Upgrade[i].interactable = false;
//            }
//        }


//    }


//    void Update()
//    {


//        for (int i = 0; i < Upgrade.Length; i++)
//        {
//            if (Pontos.scoreNumber >= PontosNecessarios[i])
//            {
//                FazerUpgrade();
//                if (i == 0 && !JaUsou[i])
//                {
//                    Upgrade[i].interactable = true;
//                }
//                else
//                {
//                    if (!JaUsou[i] && JaUsou[i - 1])
//                    {
//                        Upgrade[i].interactable = true;
//                    }
//                }
//            }
//            else
//            {
//                Upgrade[i].interactable = false;
//            }

//        }

//        barrinha.fillAmount = valorFill;
//    }

//    public void FazerUpgrade()
//    {
//        for (int i = 0; i < Upgrade.Length; i++)
//        {

//            if (i == 0 && upgradesScripts[i].Clicou && !JaUsou[i])
//            {

//                Pontos.scoreNumber -= PontosNecessarios[i];
//                Upgrade[i].interactable = false;
//                Upgrade[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                JaUsou[i] = true;
//                valorFill += 0.17f;
//            }
//            else if (i > 0)
//            {
//                if (upgradesScripts[i].Clicou && JaUsou[i - 1] && !JaUsou[i])
//                {
//                    Pontos.scoreNumber -= PontosNecessarios[i];
//                    Upgrade[i].interactable = false;
//                    Upgrade[i].GetComponent<Image>().color = new Color(152, 125, 125);
//                    JaUsou[i] = true;
//                    valorFill += 0.17f;
//                }
//            }
//        }




//    }
//}

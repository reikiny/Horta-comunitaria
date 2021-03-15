using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Pontos : MonoBehaviour
{
    Text score;
    public static int scoreNumber;
  
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        Pontuacao();
    }

    void Pontuacao()
    {
        score.text = scoreNumber.ToString();
    }
}

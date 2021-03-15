using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text text;
    public Text tipo;
    public int max, current, min;
    public Image fill;
    public Image icone;
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmout = currentOffset / maxOffset;
        fill.fillAmount = fillAmout;
        text.text = currentOffset + " /  " + maxOffset;
    }
}

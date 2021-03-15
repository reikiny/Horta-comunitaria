using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableGarden : MonoBehaviour
{
    public string objecto;
    public float time;
    float timeReset;
    public bool timer;
    bool começa;

    private void Start()
    {
        timeReset = time;
    }

    private void Update()
    {
        if (timer)
        {
            GetComponent<Button>().interactable = false;
            if (time <= 0)
            {
                começa = true;
                GetComponent<Button>().interactable = true;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

    }
    public void PegarOItem()
    {
        if (!timer)
        {
            GardenItens.Gardenitens = objecto;
            Debug.Log(GardenItens.Gardenitens);
        }
        if (timer)
        {

            if (começa)
            {
                GetComponent<Button>().interactable = false;
                GardenItens.Gardenitens = objecto;
                Debug.Log(GardenItens.Gardenitens);
                começa = false;
                time = timeReset;
                
            }
            time -= Time.deltaTime;
        }
    }
}

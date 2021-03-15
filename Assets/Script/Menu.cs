using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string start;
    [Space]
    public GameObject credit;



    public void Started()
    {
        SceneManager.LoadScene(start);
    }
    public void Credit()
    {
        credit.SetActive(true);
    }
    public void BackMenu()
    {
        credit.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

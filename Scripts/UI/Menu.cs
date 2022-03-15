using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditUI;
    public GameObject howUI;
    public GameObject readUI;

    public static bool creditIsOn;
    public static bool howIsOn;
    public static bool readIsOn;

    public void Start()
    {
        creditIsOn = false;
        howIsOn = false;
        readIsOn = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (creditIsOn == true)
            {
                CreditOff();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (howIsOn == true)
            {
                HowOff();
            }
        }
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Quit...");
        Application.Quit();
    }

    public void CreditsOn()
    {
        creditUI.SetActive(true);
        creditIsOn = true;
    }

    public void CreditOff()
    {
        creditUI.SetActive(false);
        creditIsOn = false;
    }

    public void HowOn()
    {
        howUI.SetActive(true);
        howIsOn = true;
    }

    public void HowOff()
    {
        howUI.SetActive(false);
        howIsOn = false;
    }

    public void ReadOn()
    {
        readUI.SetActive(true);
        readIsOn = true;
    }

    public void ReadOff()
    {
        readUI.SetActive(false);
        readIsOn = false;
    }
}

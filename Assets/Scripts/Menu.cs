using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public Canvas creditsCanvas;

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");

        //creditsCanvas.gameObject.SetActive(true); // Enable the Canvas
    }

    public void CloseCredits()
    {
        SceneManager.LoadScene("Menu");
        //creditsCanvas.gameObject.SetActive(false); // Disable the Canvas
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

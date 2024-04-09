using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

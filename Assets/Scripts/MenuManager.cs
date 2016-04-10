using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public void LoadGame()
    {
        Application.LoadLevel(2);
    }
    public void LoadMenu()
    {
        Application.LoadLevel(0);
    }
    public void LoadCredits()
    {
        Application.LoadLevel(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

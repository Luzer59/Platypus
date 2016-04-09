using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject activator;

    void Update()
    {
        if (GameController.instance.gameState == GameState.Menu)
        {
            if (!activator.activeInHierarchy)
            {
                activator.SetActive(true);
            }
        }
        else
        {
            if (activator.activeInHierarchy)
            {
                activator.SetActive(false);
            }
        }
    }
}

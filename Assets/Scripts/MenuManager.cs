using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public ParticleSystem[] part;
    public float confettiDelay;

    private int partIndex = 0;

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

    void Start()
    {
        if (part.Length != 0)
        {
            StartCoroutine(PartLoop());
        }
    }

    IEnumerator PartLoop()
    {
        while (true)
        {
            int random = 0;
            if (part.Length > 1)
            {
                while (true)
                {
                    random = Random.Range(0, part.Length);
                    if (random != partIndex)
                    {
                        break;
                    }
                }
            }
            partIndex = random;
            part[partIndex].Play();
            yield return new WaitForSeconds(confettiDelay);
        }
    }
}

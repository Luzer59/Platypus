using UnityEngine;
using System.Collections;

public class ConfettiMK2 : MonoBehaviour
{
    ParticleSystem part;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        GameController.instance.OnGameEnd += SpawnConfetti;
    }

    void SpawnConfetti()
    {
        part.Play();
    }
}

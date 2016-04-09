using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Confetti : MonoBehaviour {

    public int player1or2Confetti = 1;

    public int amount = 60;
    public int maxSpeed = 20;
    public int minSpeed = 10;

    public GameObject confetti;

    GameController gc;
    List<GameObject> allConfetti = new List<GameObject>();

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnConfetti();   
        }

        if (gc.gameState == GameState.GameEnd)
        {
            if (gc.player1won)
            {
                if (!gc.confettiShot && player1or2Confetti == 1)
                {
                    SpawnConfetti();
                    gc.confettiShot = true;
                }
            }
            else if (gc.player2won)
            {
                if (!gc.confettiShot && player1or2Confetti == 2)
                {
                    SpawnConfetti();
                    gc.confettiShot = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < allConfetti.Count; i++)
            {
                GameObject.Destroy(allConfetti[i]);                
            }
            allConfetti.Clear();
        }
	}
    void SpawnConfetti()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject instance = (GameObject)Instantiate(confetti, transform.position, Quaternion.identity);
            allConfetti.Add(instance);
            instance.GetComponent<ConfettiMover>().SetValues(this.gameObject.transform, maxSpeed, minSpeed);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Player2 : Player1
{
    protected override void Start()
    {
        base.Start();
        Reset();
    }

    override protected void CheckHealth()
    {
        if (currentLife <= 0)
        {
            gameController.player2Alive = false;
        }
    }
}

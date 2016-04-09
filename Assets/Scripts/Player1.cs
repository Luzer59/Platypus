using UnityEngine;
using System.Collections;

public class Player1 : PlayerBase
{
    protected override void Start()
    {
        base.Start();
        Reset();
    }

    protected override void Update()
    {
        base.Update();
        SetActiveStatus();
    }

    protected override void CheckHealth()
    {
        if (currentLife <= 0)
        {
            gameController.player1Alive = false;
        }
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player1Alive = true;
        position = 0f;
    }
}

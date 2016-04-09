using UnityEngine;
using System.Collections;

public class Player2 : PlayerBase
{
    protected override void Start()
    {
        base.Start();
        Reset();
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player2Alive = true;
        position = 0f;
    }
}

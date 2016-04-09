using UnityEngine;
using System.Collections;

public class Player1 : PlayerBase
{
    public int healthGain;
    public int healthLoss;

    protected override void Start()
    {
        base.Start();
        Reset();
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player1Alive = true;
        position = 0f;
    }
}

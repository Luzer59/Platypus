using UnityEngine;
using System.Collections;

public class Attacker : Player
{
    void Start()
    {
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
            GameController.instance.attackerAlive = false;
        }
    }

    public override void Reset()
    {
        currentLife = maxLife;
        GameController.instance.attackerAlive = true;
        position = 0f;
    }
}

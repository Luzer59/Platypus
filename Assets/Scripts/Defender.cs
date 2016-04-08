using UnityEngine;
using System.Collections;

public class Defender : Attacker
{
    override protected void CheckHealth()
    {
        if (currentLife <= 0)
        {
            GameController.instance.defenderAlive = false;
        }
    }
}

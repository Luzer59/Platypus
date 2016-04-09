using UnityEngine;
using System.Collections;

public class Player1 : PlayerBase
{
    public int healthGain;
    public int healthLoss;

    protected override void Update()
    {
        base.Update();
        Movement();
    }

    protected override void Start()
    {
        base.Start();
        Reset();
    }

    void Movement()
    {
        if (Input.GetKey(button) && controlsActive && !gameController.gameEnd)
        {
            position += speed;
        }
        else
        {
            position -= speed;
        }

        position = Mathf.Clamp01(position);

        Vector2 currentPos = Vector2.Lerp(startPos, endPos, position);
        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
        transform.Rotate(Vector3.forward, 10);
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player1Alive = true;
        position = 0f;
    }
}

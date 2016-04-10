using UnityEngine;
using System.Collections;

public class Player1 : PlayerBase
{
    public int healthGain;
    public int healthLoss;

    protected override void Update()
    {
        if (gameController.gameState == GameState.GamePlay)
        {
            base.Update();
            Movement();
            CheckMovingStatus();
        }
    }

    protected override void Start()
    {
        base.Start();
        Reset();
    }

    void Movement()
    {
        lastPosition = position;
        if ((Input.GetKey(button) || MobileInput.GetTouch(playerSide)) && controlsActive && gameController.gameState == GameState.GamePlay)
        {
            position += speed;
        }
        else
        {
            position -= speed;
        }

        SetPosition();
    }

    void SetPosition()
    {
        position = Mathf.Clamp01(position);

        Vector2 currentPos = Vector2.Lerp(startPos[gameController.currentSpriteSet], endPos[gameController.currentSpriteSet], position);

        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player1Alive = true;
        position = 0f;
        lastPosition = position;
        active = false;
        SetPosition();
    }
}

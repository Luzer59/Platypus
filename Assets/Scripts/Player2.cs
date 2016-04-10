using UnityEngine;
using System.Collections;

public class Player2 : PlayerBase
{
    private bool activatedNow;
    private bool forceBack = false;

    protected override void Start()
    {
        base.Start();
        Reset();
    }

    protected override void Update()
    {
        if (gameController.gameState == GameState.GamePlay)
        {
            base.Update();
            Movement();
            ActivateAttack();
            CheckMovingStatus();
        }
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player2Alive = true;
        position = 0;
        lastPosition = position;
        active = false;
        SetPosition();
    }

    void ActivateAttack()
    {
        if (active && !activatedNow && (Input.GetKey(button) || MobileInput.GetTouch(playerSide)))
        {
            gameController.Player2AttackCheck();
            StartCoroutine(AttackTimer());
        }
    }

    void Movement()
    {
        lastPosition = position;
        if (gameController.gameState == GameState.GamePlay)
        {
            if (Input.GetKey(button) || MobileInput.GetTouch(playerSide))
            {
                if (controlsActive)
                {
                    position += speed;
                }
            }
            else
            {
                if (controlsActive)
                {
                    position -= speed;
                }

            }

            if (forceBack)
            {
                position -= speed;
            }
        }
        SetPosition();
    }

    void SetPosition()
    {
        position = Mathf.Clamp01(position);

        Vector2 currentPos = Vector2.Lerp(startPos[gameController.currentSpriteSet], endPos[gameController.currentSpriteSet], position);

        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
    }

    IEnumerator AttackTimer()
    {
        activatedNow = true;
        controlsActive = false;
        yield return new WaitForSeconds(0.5f);
        forceBack = true;
        yield return new WaitForSeconds(0.5f);
        forceBack = false;
        controlsActive = true;
        activatedNow = false;
    }
}

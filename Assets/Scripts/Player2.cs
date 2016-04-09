using UnityEngine;
using System.Collections;

public class Player2 : PlayerBase
{
    private bool activatedNow;

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
        position = 0f;
        lastPosition = position;
    }

    void ActivateAttack()
    {
        if (active && !activatedNow && Input.GetKey(button))
        {
            controlsActive = false;
            activatedNow = true;
            gameController.Player2AttackCheck();
            StartCoroutine(AttackTimer());
        }
    }

    void Movement()
    {
        lastPosition = position;
        if (Input.GetKey(button) && controlsActive && gameController.gameState == GameState.GamePlay)
        {
            position += speed;
        }
        else if (!activatedNow)
        {
            position -= speed;
        }

        position = Mathf.Clamp01(position);

        Vector2 currentPos = Vector2.Lerp(startPos, endPos, position);
        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
        transform.Rotate(Vector3.forward, 10);
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1f);
        activatedNow = false;
        controlsActive = true;
    }
}

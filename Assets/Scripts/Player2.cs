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
        base.Update();
        Movement();
        ActivateAttack();
    }

    public override void Reset()
    {
        currentLife = maxLife;
        gameController.player2Alive = true;
        position = 0f;
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
        if (Input.GetKey(button) && controlsActive && !gameController.gameEnd)
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

using UnityEngine;
using System.Collections;

public abstract class PlayerBase : MonoBehaviour
{
    public float position;
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed;
    public string button;
    public float activeZone;
    public float maxLife;
    public bool active;

    protected float currentLife;
    protected GameController gameController;

    public float Life
    {
        get { return currentLife; }
        set { currentLife = value; }
    }

    protected virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected virtual void Update()
    {
        Movement();
        SetActiveStatus();
    }

    protected void SetActiveStatus()
    {
        if (position >= 1f - activeZone)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    public abstract void Reset();

    void Movement()
    {
        if (Input.GetKey(button) && !gameController.gameEnd)
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
}

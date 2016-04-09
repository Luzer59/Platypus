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
    public int maxLife;
    public bool active;

    protected int currentLife;
    protected GameController gameController;

    public int Life
    {
        get { return currentLife; }
        set { currentLife = value; }
    }

    protected virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
    
    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        CheckHealth();
    }

    protected abstract void CheckHealth();

    protected virtual void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(button))
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

using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour
{
    public float position;
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed;
    public string button;
    public float activeZone;
    public float maxLife;
    public float currentLife;
    public bool active;

    protected bool controlsActive = true;
    protected GameController gameController;

    protected virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected virtual void Update()
    {
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

    public virtual void Reset()
    {

    }
}

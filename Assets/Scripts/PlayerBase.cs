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
    public bool isMoving = false;
    public AudioClip[] actionSound;
    public Direction playerSide;

    protected bool controlsActive = true;
    protected GameController gameController;
    protected float lastPosition;
    protected AudioSource audio;

    protected virtual void Start()
    {
        audio = GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected virtual void Update()
    {
        SetActiveStatus();
        PlayActionSound();
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

    void PlayActionSound()
    {
        if (Input.GetKey(button) || MobileInput.GetTouch(playerSide))
        {
            int random = Random.Range(0, actionSound.Length);
            audio.PlayOneShot(actionSound[random]);
        }
    }

    protected void CheckMovingStatus()
    {
        if (!Mathf.Approximately(position, lastPosition))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}

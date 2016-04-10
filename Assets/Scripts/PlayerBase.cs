using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerSound
{
    public AudioClip[] clip;
}

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
    public PlayerSound[] activationSound;
    public PlayerSound[] deactivationSound;
    public Direction playerSide;
    public bool[] spriteMove;

    protected bool controlsActive = true;
    protected GameController gameController;
    protected float lastPosition;
    protected AudioSource audio;
    protected bool lastActive = false;

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
        if (!lastActive && active)
        {
            if (activationSound[gameController.currentSpriteSet].clip.Length > 0)
            {
                int random = Random.Range(0, activationSound[gameController.currentSpriteSet].clip.Length);
                audio.PlayOneShot(activationSound[gameController.currentSpriteSet].clip[random]);
            }
        }
        else if (lastActive && !active)
        {
            if (deactivationSound[gameController.currentSpriteSet].clip.Length > 0)
            {
                int random = Random.Range(0, deactivationSound[gameController.currentSpriteSet].clip.Length);
                audio.PlayOneShot(deactivationSound[gameController.currentSpriteSet].clip[random]);
            }
        }

        lastActive = active;
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

using UnityEngine;
using System.Collections;

public enum AnimationMode { Movement, SpriteAnimation }

[System.Serializable]
public class PlayerSprites
{
    public Sprite[] sprites;
}

[RequireComponent(typeof(SpriteRenderer))]
public class CustomAnimator : MonoBehaviour
{
    public PlayerSprites[] sprites;
    public PlayerBase player;
    public float[] scale;

    private SpriteRenderer sr;
    private int currentSpriteIndex = 0;

    void Start()
    {
        GameController.instance.OnGameStart += SetNewSprites;
        sr = GetComponent<SpriteRenderer>();
    }

    void SetNewSprites()
    {
        currentSpriteIndex = GameController.instance.currentSpriteSet;
        transform.localScale = new Vector3(scale[currentSpriteIndex], scale[currentSpriteIndex], scale[currentSpriteIndex]);
    }

    void Update()
    {
        sr.sprite = sprites[currentSpriteIndex].sprites[Mathf.RoundToInt((sprites[currentSpriteIndex].sprites.Length - 1) * player.position)];
    }
}

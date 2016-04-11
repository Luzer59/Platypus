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
    public int[] order;

    private SpriteRenderer sr;
    private int currentSpriteIndex = 0;

    void Start()
    {
        GameController.instance.OnGameStart += SetNewSprites;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentSpriteIndex = GameController.instance.currentSpriteSet;
        sr.sprite = sprites[currentSpriteIndex].sprites[Mathf.RoundToInt((sprites[currentSpriteIndex].sprites.Length - 1) * player.position)];
    }

    void SetNewSprites()
    {
        transform.localScale = new Vector3(scale[currentSpriteIndex], scale[currentSpriteIndex], scale[currentSpriteIndex]);
        sr.sortingOrder = order[currentSpriteIndex];
    }
}

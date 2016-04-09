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

    private SpriteRenderer sr;
    private int currentSpriteIndex = 0;

    void Start()
    {
        GameController.instance.OnGameStart += SetNewSprites;
        sr = GetComponent<SpriteRenderer>();
    }

    void SetNewSprites()
    {
        int random = 0;
        if (sprites.Length > 1)
        {
            while (true)
            {
                random = Random.Range(0, sprites.Length);
                if (random != currentSpriteIndex)
                {
                    break;
                }
            }
        }
        currentSpriteIndex = random;
    }

    void Update()
    {
        sr.sprite = sprites[currentSpriteIndex].sprites[Mathf.RoundToInt((sprites[currentSpriteIndex].sprites.Length - 1) * player.position)];
    }
}

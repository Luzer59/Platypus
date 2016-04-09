using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CustomAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public PlayerBase player;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.sprite = sprites[Mathf.RoundToInt((sprites.Length - 1) * player.position)];
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public string targetTag;

    private PlayerBase player;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag(targetTag).GetComponent<PlayerBase>();
    }

    void Update()
    {
        image.fillAmount = player.currentLife / player.maxLife;
    }
}

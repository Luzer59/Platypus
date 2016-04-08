using UnityEngine;
using System.Collections;

public class ApacheEffect : MonoBehaviour
{

    Player player1Script;

    public SpriteRenderer background;
    float lerpTime = 0.2f;
    float currentLerpTime;
    bool resetLerp;
    Color fadeStartValue;
    Color fadeEndValue;

    void Start()
    {
        player1Script = GameObject.Find("Player1").GetComponent<Player>();
    }

    void Update()
    {
        FadeRooms();
    }
    void FadeRooms()
    {
        if (player1Script.GetActiveStatus() == true)
        {
            if (resetLerp)
            {
                currentLerpTime = 0;
                resetLerp = false;
                fadeStartValue = background.color;
            }

            fadeEndValue = new Color(background.color.r, background.color.g, background.color.b, 0.0f);

            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;

            Color newFadeValue = Color.Lerp(fadeStartValue, fadeEndValue, perc);

            background.color = newFadeValue;
        }
        else
        {
            if (!resetLerp)
            {
                currentLerpTime = 0;
                resetLerp = true;
                fadeStartValue = background.color;
            }

            fadeEndValue = new Color(background.color.r, background.color.g, background.color.b, 1.0f);

            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;

            Color newFadeValue = Color.Lerp(fadeStartValue, fadeEndValue, perc);

            background.color = newFadeValue;
        }
    }
}
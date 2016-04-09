using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApacheEffect : MonoBehaviour
{
    Player1 player1Script;
    GameController gc;

    public GameObject apache;
    List<GameObject> apacheList = new List<GameObject>();
    public int apacheCount;

    public List<Sprite> levelTypes = new List<Sprite>();
    public List<Sprite> apacheTypes = new List<Sprite>();

    int currentLevelType = 0;
    SpriteRenderer background;
    SpriteRenderer backBackground;
    float lerpTime = 0.2f;
    float currentLerpTime;
    bool resetLerp;
    Color fadeStartValue;
    Color fadeEndValue;

    public float apacheMinHeight = 0.6f;

    void Start()
    {
        player1Script = GameObject.Find("Player1").GetComponent<Player1>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        backBackground = GameObject.FindGameObjectWithTag("BackBackground").GetComponent<SpriteRenderer>();

        SetLevelType();
        SpawnApaches();
        SetApacheSprites();           
    }

    void Update()
    {
        FadeBackground();
    }
    void FadeBackground()
    {
        if (player1Script.active == true)
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
    void SetLevelType()
    {
        //set level type (= background)
        Sprite newLevelBack = null;
        Sprite oldLevelBack = newLevelBack;
        while (newLevelBack == null || newLevelBack == oldLevelBack)
        {
            currentLevelType = Random.Range(0, levelTypes.Count);
            newLevelBack = levelTypes[currentLevelType];
            background.sprite = newLevelBack;
            backBackground.sprite = newLevelBack;
        }
    }
    void SpawnApaches()
    {
        for (int i = 0; i < apacheCount; i++)
        {
            GameObject instance = (GameObject)Instantiate(apache, new Vector3(0, 0, 0), Quaternion.identity);
            apacheList.Add(instance);            
        }
    }
    void SetApacheSprites()
    {
        //sprites depending on level type
        for (int i = 0; i < apacheList.Count; i++)
        {
            switch (currentLevelType)
            {
                case 0:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(0, 2)];
                    break;
                case 1:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(1, 3)];
                    break;
                case 2:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(2, 4)];
                    break;
                default:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(0, 1)];
                    break;
            }
        }
    }
}
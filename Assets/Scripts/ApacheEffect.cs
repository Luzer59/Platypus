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

    public GameObject speedline;
    List<GameObject> speedlineList = new List<GameObject>();
    public int speedlineCount;

    public List<Sprite> levelTypes = new List<Sprite>();
    public List<Sprite> levelBackTypes = new List<Sprite>();
    public List<Sprite> apacheTypes = new List<Sprite>();

    int currentLevelType = 0;
    Sprite newLevelBack = null;
    SpriteRenderer background;
    SpriteRenderer backBackground;

    float lerpTime = 0.2f;
    float currentLerpTime;
    bool resetLerp;
    Color fadeStartValue;
    Color fadeEndValue;

    public float apacheMaxHeight = 3.5f;
    public float apacheMinHeight = -3.5f;

    void Awake()
    {
        player1Script = GameObject.Find("Player1").GetComponent<Player1>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        backBackground = GameObject.FindGameObjectWithTag("BackBackground").GetComponent<SpriteRenderer>();     
    }
    void Start()
    {
        SpawnSpeedlines();
    }

    void Update()
    {
        FadeBackground();
    }
    void FadeBackground()
    {
        if (player1Script.active)
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
        Sprite oldLevelBack = newLevelBack;
        while (newLevelBack == null || newLevelBack == oldLevelBack)
        {
            currentLevelType = Random.Range(0, levelTypes.Count);
            newLevelBack = levelTypes[currentLevelType];
            background.sprite = newLevelBack;
            backBackground.sprite = levelBackTypes[currentLevelType];
        }
    }
    void SpawnApaches()
    {
        float spawnAreaPartX = apacheCount / 22;
        float spawnPosMinX = -11;
        float spawnPosMaxX = -11 + spawnAreaPartX;

        float spawnPosMinY = apacheMinHeight;
        float spawnPosMaxY = apacheMaxHeight;

        if (apacheList.Count < apacheCount)
        {
            for (int i = 0; i < apacheCount; i++)
            {
                GameObject instance = (GameObject)Instantiate(apache, new Vector3(0, 0, 0), Quaternion.identity);
                apacheList.Add(instance);

                float spawnPosX = Random.Range(spawnPosMinX, spawnPosMaxX);
                float spawnPosY = Random.Range(spawnPosMinY, spawnPosMaxY);
                instance.transform.position = new Vector3(spawnPosX, spawnPosY, 0);

                spawnPosMinX += spawnAreaPartX;
                spawnPosMaxX += spawnAreaPartX;

                instance.GetComponent<ApacheMover>().SetValues(Random.Range(5, 20));
            }
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
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(0, 3)];
                    break;
                case 1:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(3, 5)];
                    break;
                case 2:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(5, 7)];
                    break;
                case 3:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(7, 9)];
                    break;
                default:
                    apacheList[i].GetComponent<SpriteRenderer>().sprite = apacheTypes[Random.Range(0, 1)];
                    break;
            }
        }
    }
    public void NewLevel()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1.0f); 
        SetLevelType();
        SpawnApaches();
        SetApacheSprites();
    }
    public void SpawnSpeedlines()
    {
        float spawnAreaPartX = speedlineCount / 22;
        float spawnPosMinX = -11;
        float spawnPosMaxX = -11 + spawnAreaPartX;

        float spawnPosMinY = apacheMinHeight;
        float spawnPosMaxY = apacheMaxHeight;

        if (speedlineList.Count < speedlineCount)
        {
            for (int i = 0; i < speedlineCount; i++)
            {
                GameObject instance = (GameObject)Instantiate(speedline, new Vector3(0, 0, 0), Quaternion.identity);
                speedlineList.Add(instance);

                float spawnPosX = Random.Range(spawnPosMinX, spawnPosMaxX);
                float spawnPosY = Random.Range(spawnPosMinY, spawnPosMaxY);
                instance.transform.position = new Vector3(spawnPosX, spawnPosY, 0);

                spawnPosMinX += spawnAreaPartX;
                spawnPosMaxX += spawnAreaPartX;

                instance.GetComponent<SpeedlineMover>().SetValues(Random.Range(5, 20));
            }
        }
    }
}
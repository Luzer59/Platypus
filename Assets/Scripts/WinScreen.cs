using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    private Image image;
    new private Transform transform;
    private Vector3 originPos;
    private Vector3 originalOriginPos;
    private bool active = false;

    public float shakeIntensity;
    public Sprite player1WinText;
    public Sprite player2WinText;
    public GameObject ninja;

    void Start()
    {
        image = GetComponent<Image>();
        transform = GetComponent<RectTransform>();
        originPos = transform.position;
        originalOriginPos = originPos;
        GameController.instance.OnGameEnd += OnGameEnd;
    }

    void OnGameEnd()
    {
        StartCoroutine(Effect(GameController.instance.endGameDelay));
    }

    void Update()
    {
        if (active)
        {
            Vector2 random = Random.insideUnitCircle * shakeIntensity;
            transform.position = new Vector3(originPos.x + random.x, originPos.y + random.y, originPos.z);
        }
    }

    IEnumerator Effect(float showDuration)
    {
        if (GameController.instance.roundTimer >= GameController.instance.roundStartTime - 1f)
        {
            ninja.SetActive(true);
        }
        active = true;
        if (GameController.instance.player1Alive)
        {
            originPos = originalOriginPos - new Vector3(4f, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, 20f);
            image.sprite = player1WinText;
        }
        else
        {
            originPos = originalOriginPos + new Vector3(4f, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, -20f);
            image.sprite = player2WinText;
        }
        image.enabled = true;
        yield return new WaitForSeconds(showDuration);
        transform.rotation = Quaternion.Euler(0f, 0f,0f);
        image.enabled = false;
        active = false;
        if (ninja.activeInHierarchy)
        {
            ninja.SetActive(false);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    private Image image;
    new private Transform transform;
    private Vector3 originPos;
    private bool active = false;

    public float shakeIntensity;
    public Sprite player1WinText;
    public Sprite player2WinText;

    void Start()
    {
        image = GetComponent<Image>();
        transform = GetComponent<RectTransform>();
        originPos = transform.position;
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
        active = true;
        if (GameController.instance.player1Alive)
        {
            image.sprite = player1WinText;
        }
        else
        {
            image.sprite = player2WinText;
        }
        image.enabled = true;
        yield return new WaitForSeconds(showDuration);
        image.enabled = false;
        active = false;
    }
}

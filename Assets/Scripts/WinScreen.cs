using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    private Text text;
    new private Transform transform;
    private Vector3 originPos;
    private bool active = false;

    public float shakeIntensity;
    public string player1WinText;
    public string player2WinText;

    void Start()
    {
        text = GetComponent<Text>();
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
            text.text = player1WinText;
        }
        else
        {
            text.text = player2WinText;
        }
        text.enabled = true;
        yield return new WaitForSeconds(showDuration);
        text.enabled = false;
        active = false;
    }
}

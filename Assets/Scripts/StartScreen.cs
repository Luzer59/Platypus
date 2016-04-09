using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    private Text text;
    new private Transform transform;
    private Vector3 originPos;
    private bool active = false;

    public float shakeIntensity;

    void Start()
    {
        text = GetComponent<Text>();
        transform = GetComponent<RectTransform>();
        originPos = transform.position;
        GameController.instance.OnGameStart += OnGameStart;
    }

    void OnGameStart()
    {
        StartCoroutine(Effect(GameController.instance.startGameDelay));
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
        text.enabled = true;
        yield return new WaitForSeconds(showDuration);
        text.enabled = false;
        active = false;
    }
}

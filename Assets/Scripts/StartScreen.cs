using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    private Image image;
    new private Transform transform;
    private Vector3 originPos;
    private bool active = false;

    public float shakeIntensity;

    void Start()
    {
        image = GetComponent<Image>();
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
        image.enabled = true;
        yield return new WaitForSeconds(showDuration);
        image.enabled = false;
        active = false;
    }
}

using UnityEngine;
using System.Collections;

public class UIShake : MonoBehaviour
{
    public float intensity;
    public bool shakeActive;

    new private RectTransform transform;
    private Vector3 originPos;
    private bool shakeWasActive = false;

    void Start()
    {
        transform = GetComponent<RectTransform>();
        originPos = transform.position;
        if (GameController.instance)
        {
            GameController.instance.uiShake = this;
        }
    }

    void Update()
    {
        if (GameController.instance)
        {
            if (GameController.instance.gameState == GameState.GamePlay)
            {
                if (shakeActive)
                {
                    ShakeShakeShake();
                    shakeWasActive = true;
                }
                else if (shakeWasActive)
                {
                    ShakeReset();
                    shakeWasActive = false;
                }
            }
            else if (shakeWasActive)
            {
                ShakeReset();
                shakeWasActive = false;
            }
        }
        else
        {
            if (shakeActive)
            {
                ShakeShakeShake();
                shakeWasActive = true;
            }
            else if (shakeWasActive)
            {
                ShakeReset();
                shakeWasActive = false;
            }
        }
    }

    void ShakeShakeShake()
    {
        Vector2 random = Random.insideUnitCircle * intensity;
        transform.position = new Vector3(originPos.x + random.x, originPos.y + random.y, originPos.z);
    }

    void ShakeReset()
    {
        transform.position = originPos;
    }

    public void ShakeForTime(float duration)
    {
        StartCoroutine(Shakeeeee(duration));
    }

    IEnumerator Shakeeeee(float duration)
    {
        shakeActive = true;
        yield return new WaitForSeconds(duration);
        shakeActive = false;
    }
}

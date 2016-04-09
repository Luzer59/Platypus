using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float intensity;
    public bool shakeActive;

    private Camera camera;
    new private Transform transform;
    private Vector3 originPos;
    private bool shakeWasActive = false;

    void Start()
    {
        camera = GetComponent<Camera>();
        transform = GetComponent<Transform>();
        originPos = transform.position;
        GameController.instance.cameraShake = this;
    }

    void Update()
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
}

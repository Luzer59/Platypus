using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float position;
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed;
    public string button;
    public float activeZone;

    void Update()
    {
        if (Input.GetKey(button))
        {
            position += speed;
        }
        else
        {
            position -= speed;
        }

        position = Mathf.Clamp01(position);

        Vector2 currentPos = Vector2.Lerp(startPos, endPos, position);
        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
        transform.Rotate(Vector3.forward, 10);
    }

    public bool GetActiveStatus()
    {
        if (position >= 1f - activeZone)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

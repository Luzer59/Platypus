using UnityEngine;
using System.Collections;

public enum UiItemType { Text, Image }

public class PopupEffect : MonoBehaviour
{
    public UiItemType type;

    public void Activate(float duration)
    {
        StartCoroutine(Effect(duration));
    }

    IEnumerator Effect(float duration)
    {
        float timer = duration;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            if (type == UiItemType.Text)
            {

            }

            yield return null;
        }
    }
}

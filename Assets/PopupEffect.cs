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
        yield return new WaitForSeconds(2f);
        if (type == UiItemType.Text)
        {

        }
    }
}

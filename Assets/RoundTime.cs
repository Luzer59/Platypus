using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoundTime : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = GameController.instance.roundTimer.ToString("0.0");
    }
}

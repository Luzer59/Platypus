using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Streak : MonoBehaviour
{
    public Text player1Indicator;
    public Text player2Indicator;

    public int current1Value = 0;
    public int current2Value = 0;

    private GameController gc;

    void Start()
    {
        gc = GameController.instance;
    }

    void Update()
    {
        if (gc.player1Streak != current1Value)
        {
            current1Value = gc.player1Streak;
            if (player2Indicator)
            {
                if (current1Value == 0)
                {
                    player1Indicator.text = "0 Streak";
                    player1Indicator.enabled = false;
                }
                else
                {
                    player1Indicator.text = current1Value + " Streak";
                    if (!player1Indicator.enabled)
                    {
                        player1Indicator.enabled = true;
                    }
                }
            }
        }
        if (gc.player2Streak != current2Value)
        {
            current2Value = gc.player2Streak;
            if (player2Indicator)
            {
                if (current2Value == 0)
                {
                    player2Indicator.text = "0 Streak";
                    player2Indicator.enabled = false;
                }
                else
                {
                    if (!player2Indicator.enabled)
                    {
                        player2Indicator.enabled = true;
                    }
                    player2Indicator.text = current2Value + " Streak";
                }
            }
        }
    }
}

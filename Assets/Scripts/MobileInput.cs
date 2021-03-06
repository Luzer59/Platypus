﻿using UnityEngine;
using System.Collections;

public enum Direction { Left, Right }

public class MobileInput : MonoBehaviour
{
    public static bool GetTouch(Direction dir)
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (dir == Direction.Left)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        return true;
                    }
                }
                else if (dir == Direction.Right)
                {
                    if (touch.position.x >= Screen.width / 2)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

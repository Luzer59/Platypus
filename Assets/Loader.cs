using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject gameController;

    void Awake()
    {
        GameObject go;

        if (GameController.instance == null)
        {
            go = Instantiate(gameController);
            go.transform.SetParent(transform);
        }
    }
}

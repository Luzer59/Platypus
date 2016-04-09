using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    #region Singleton structure
    public static GameController instance = null;

    void InitializeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public Player1 player1;
    public Player2 player2;
    public bool player1Alive = true;
    public bool player2Alive = true;

    void Awake()
    {
        InitializeSingleton();
    }

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();
    }

    void Update()
    {
        CheckPlayers();
    }

    void CheckPlayers()
    {
        if (player1.active && player2.active)
        {
            print("defender win");
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        player1.Reset();
        player2.Reset();
    }
}

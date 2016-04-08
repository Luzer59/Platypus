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

    public Attacker attacker;
    public Defender defender;
    public bool attackerAlive = true;
    public bool defenderAlive = true;

    void Awake()
    {
        InitializeSingleton();
    }

    void Start()
    {
        attacker = GameObject.FindGameObjectWithTag("Attacker").GetComponent<Attacker>();
        defender = GameObject.FindGameObjectWithTag("Defender").GetComponent<Defender>();
    }

    void Update()
    {
        CheckPlayers();
    }

    void CheckPlayers()
    {
        if (attacker.active && defender.active)
        {
            print("defender win");
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        attacker.Reset();
        defender.Reset();
    }
}

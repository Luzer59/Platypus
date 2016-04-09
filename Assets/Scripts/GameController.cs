using UnityEngine;
using System.Collections;

public enum ShakeCondition { WhenActive, WhenMoving }
public enum GameState { Start, GamePlay, GameEnd, Menu }

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
    public float roundStartTime;
    public float roundTimer = 0f;
    public CameraShake cameraShake;
    public UIShake uiShake;
    public ShakeCondition shakeCondition;
    public GameState gameState = GameState.Start;
    public float startGameDelay;
    public float endGameDelay;

    private GameState savedState;
    private ApacheEffect apacheEffect;

    void Awake()
    {
        InitializeSingleton();
    }

    void Start()
    {
        apacheEffect = GetComponent<ApacheEffect>();
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();
        Reset();
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (gameState != GameState.Menu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                savedState = gameState;
                gameState = GameState.Menu;
            }
        }
        else if (gameState == GameState.Menu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameState = savedState;
            }
        }

        if (gameState == GameState.GamePlay)
        {
            ShakeCheck();
            TimerCountdown();
            CheckEndConditions();
        }
    }

    void Reset()
    {
        roundTimer = roundStartTime;
        if (apacheEffect)
        {
            apacheEffect.NewLevel();
        }        
    }

    void TimerCountdown()
    {
        roundTimer -= Time.deltaTime;
    }

    void ShakeCheck()
    {
        if (shakeCondition == ShakeCondition.WhenActive)
        {
            if (player1.active || player2.active)
            {
                cameraShake.shakeActive = true;
                uiShake.shakeActive = true;
            }
            else
            {
                cameraShake.shakeActive = false;
                uiShake.shakeActive = false;
            }
        }
        else if (shakeCondition == ShakeCondition.WhenMoving)
        {
            if (player1.isMoving || player2.isMoving)
            {
                cameraShake.shakeActive = true;
                uiShake.shakeActive = true;
            }
            else
            {
                cameraShake.shakeActive = false;
                uiShake.shakeActive = false;
            }
        }
    }

    void CheckEndConditions()
    {
        if (player1.active)
        {
            player1.currentLife += player1.healthGain * Time.deltaTime;
        }
        else
        {
            player1.currentLife -= player1.healthLoss * Time.deltaTime;
        }
        if (roundTimer <= 0f)
        {
            player2.currentLife = 0f;
        }
        if (player1.currentLife > player1.maxLife)
        {
            player1.currentLife = player1.maxLife;
        }
        if (player1.currentLife <= 0)
        {
            player1.currentLife = 0f;
            player1Alive = false;
        }
        if (player2.currentLife > player2.maxLife)
        {
            player2.currentLife = player2.maxLife;
        }
        if (player2.currentLife <= 0)
        {
            player2.currentLife = 0;
            player2Alive = false;
        }
        if (!player1Alive)
        {
            StartCoroutine(EndGame());
        }
        if (!player2Alive)
        {
            StartCoroutine(EndGame());
        }
    }

    public void Player2AttackCheck()
    {
        if (player1.active)
        {
            player1.currentLife -= 6969f;
        }
        else
        {
            player2.currentLife--;
        }
    }

    public System.Action OnGameEnd { get; set; }

    public System.Action OnGameStart { get; set; }

    IEnumerator StartGame()
    {
        OnGameStart();
        yield return new WaitForSeconds(startGameDelay);
        gameState = GameState.GamePlay;
    }

    IEnumerator EndGame()
    {
        OnGameEnd();
        gameState = GameState.GameEnd;
        if(player1Alive)
        {
            print("Player 1 wins");
        }
        else
        {
            print("Player 2 wins");
        }
        yield return new WaitForSeconds(endGameDelay);
        StartNewGame();
    }

    public void StartNewGame()
    {
        StartCoroutine(StartGame());
        Reset();
        player1.Reset();
        player2.Reset();
    }
}

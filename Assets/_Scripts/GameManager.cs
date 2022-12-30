using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState;

    public bool gameHasEnded = false;
    [SerializeField] private Rotator rotator;
    public GameObject gameOverMenuIU;
    public GameObject ContinueMenuIU;

    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Gameplay:
                HandleGameplay();
                break;
            case GameState.GameOver:
                HandlegameOverMenuUI();
                break;
            case GameState.Continue:
                HandledContinueMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleGameplay()
    {
        Time.timeScale = 1f;
    }

    private void HandledContinueMenu()
    {
        Time.timeScale = 0f;
    }

    private void HandlegameOverMenuUI()
    {
        if (gameHasEnded)                     //panel açýlmasý.....
            return;

        rotator.enabled = false;

        gameHasEnded = true;
        Time.timeScale = 0f;

        gameOverMenuIU.SetActive(true);
    }

    private void Start()
    {   
        rotator = GameObject.FindGameObjectWithTag("Rotator").GetComponent<Rotator>();
        UpdateGameState(GameState.Gameplay);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public enum GameState
    {
        Gameplay,
        GameOver,
        Continue
    }
}

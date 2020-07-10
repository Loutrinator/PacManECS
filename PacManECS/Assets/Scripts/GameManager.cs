using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    #endregion
    //Gameplay
    public bool isFruitActive;
    private bool _gameIsRunning;
    public bool GameIsRunning => _gameIsRunning;
    [HideInInspector] public int score;
    public float timeToStart = 5f;

    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI readyText;
    
    //Other
    private Stopwatch _startStopWatch;
    private Stopwatch _fruitStopWatch;

    private void Awake() {
        if(_instance != null && _instance != this) Destroy(gameObject);
        _instance = this;
    }
    
    private void Start()
    {
        StartNewGame();
        _fruitStopWatch = new Stopwatch();
        
    }

    private void Update()
    {
        if (_startStopWatch.IsRunning && _startStopWatch.Elapsed.Seconds >= timeToStart)
        {
            _startStopWatch.Stop();
            _fruitStopWatch.Reset();
            readyText.enabled = false;
            _gameIsRunning = true;
        }
        if (_fruitStopWatch.IsRunning && _fruitStopWatch.Elapsed.Seconds >= timeToStart)
        {
            _fruitStopWatch.Stop();
            _fruitStopWatch.Reset();
            StopFruitMode();
        }
    }

    private void StartNewGame()
    {
        _startStopWatch = Stopwatch.StartNew();
        int hs = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "HIGHSCORE\n" + hs;
        readyText.enabled = true;
    }

    public void ActivateFruitMode()
    {   _fruitStopWatch.Restart();
        isFruitActive = true;
        AudioManager.Instance.PlayFruit();
    }
    public void StopFruitMode()
    {
        isFruitActive = false;
        AudioManager.Instance.StopFruit();
    }

    public void EndGame()
    {
        AudioManager.Instance.PlayDead();
        _gameIsRunning = false;
        int hs = PlayerPrefs.GetInt("highscore");
        if (score > hs)
        {
            PlayerPrefs.SetInt("highscore",score);
            PlayerPrefs.Save();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if (_instance == null) {
                
                    _instance = new GameObject().AddComponent<GameManager>();
                    _instance.name = "GameManager";
                }
            }
            return _instance;
        }
    }
    #endregion
    //Gameplay
    public bool isFruitActive = false;
    private bool _gameIsRunning = false;
    public bool GameIsRunning => _gameIsRunning;
    [HideInInspector] public int score;
    public float timeToStart = 5f;

    //UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI readyText;
    
    //Other
    private Stopwatch startStopWatch;
    private Stopwatch fruitStopWatch;

    private void Start()
    {
        StartNewGame();
        fruitStopWatch = new Stopwatch();
        
    }

    private void Update()
    {
        if (startStopWatch.IsRunning && startStopWatch.Elapsed.Seconds >= timeToStart)
        {
            startStopWatch.Stop();
            fruitStopWatch.Reset();
            readyText.enabled = false;
            _gameIsRunning = true;
        }
        if (fruitStopWatch.IsRunning && fruitStopWatch.Elapsed.Seconds >= timeToStart)
        {
            fruitStopWatch.Stop();
            fruitStopWatch.Reset();
            StopFruitMode();
        }
    }

    private void StartNewGame()
    {
        startStopWatch = Stopwatch.StartNew();
        int hs = PlayerPrefs.GetInt("highscore");
        highscoreText.text = "HIGHSCORE\n" + hs;
        readyText.enabled = true;
    }

    public void ActivateFruitMode()
    {   fruitStopWatch.Restart();
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

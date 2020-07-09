using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    private bool doesGameStarted = false;

    public bool GameStarted => doesGameStarted;
    public float timeToStart = 5f;
    private Stopwatch SW;

    private void Start()
    {
        SW = Stopwatch.StartNew();
    }

    private void Update()
    {
        if (SW.IsRunning && SW.Elapsed.Seconds >= timeToStart)
        {
            SW.Stop();
            doesGameStarted = true;
        }
    }
}

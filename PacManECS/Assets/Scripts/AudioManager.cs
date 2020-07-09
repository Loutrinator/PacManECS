using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Instance
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
                if (_instance == null) {
                
                    _instance = new GameObject().AddComponent<AudioManager>();
                    _instance.name = "AudioManager";
                }
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] private AudioSource StartAudioSource;
    [SerializeField] private AudioSource EatingAudioSource;
    [SerializeField] private AudioSource EnemyAudioSource;
    [SerializeField] private AudioSource ChasingAudioSource;
    [SerializeField] private AudioSource FruitAudioSource;
    public void PlayEating()
    {
        EatingAudioSource.Play();
    }
    public void PlayStart()
    {
        StartAudioSource.Play();
    }
    public void PlayEnemy()
    {
        EnemyAudioSource.Play();
    }
    public void StopEnemy()
    {
        EnemyAudioSource.Stop();
    }
    public void PlayChasing()
    {
        ChasingAudioSource.Play();
    }
    public void StopChasing()
    {
        ChasingAudioSource.Stop();
    }
    public void PlayFruit()
    {
        FruitAudioSource.Play();
    }
    public void StopFruit()
    {
        FruitAudioSource.Stop();
    }
}

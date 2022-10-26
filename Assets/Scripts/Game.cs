using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public CylinderTurnScript Controls;
    public int DestroyPlatformNumber;
    public const string DestroyPlatformKey = "DestroyPlatformNumber";
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public GameObject Slider;
    public GameObject TextDestroyedPlatforms;
    public GameObject RestartButton;

    public GameObject Player;
    private ParticleSystem PlayerDieParticles;

    private void Awake()
    {
        DestroyPlatformNumber = PlayerPrefs.GetInt(DestroyPlatformKey, 0);

        PlayerDieParticles = Player.GetComponent<ParticleSystem>();
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        //Debug.Log("Game Over!");

        PlayerPrefs.SetInt(DestroyPlatformKey, 0);

        PlayerDieParticles.Play();
        //StartCoroutine(WaitBeforeSeconds(2));
        //Player.SetActive(false);

                
        Slider.SetActive(false);
        TextDestroyedPlatforms.SetActive(false);
        RestartButton.SetActive(true);
        //ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;


        CurrentState = State.Won;
        LevelIndex++;
        Controls.enabled = false;
        Debug.Log("You won!");

        PlayerPrefs.SetInt(DestroyPlatformKey, DestroyPlatformNumber);
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

   IEnumerator WaitBeforeSeconds(int _waittime)
    {
        yield return new WaitForSeconds(_waittime); 
    }
}

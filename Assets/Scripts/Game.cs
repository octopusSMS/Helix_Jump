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
    public ParticleSystem FinishParticle;

    private void Awake()
    {
        DestroyPlatformNumber = PlayerPrefs.GetInt(DestroyPlatformKey, 0);
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        //Debug.Log("Game Over!");

        PlayerPrefs.SetInt(DestroyPlatformKey, 0);

        Player.GetComponent<ParticleSystem>().Play(); //запуск системы частиц
        Destroy(Player.GetComponent<MeshRenderer>()); //отключаем отображение игрока

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
        FinishParticle.Play();

        StartCoroutine(ReloadLevelAfterTime(2f));
        //ReloadLevel();
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

    private IEnumerator ReloadLevelAfterTime(float value)
    {
        yield return new WaitForSeconds(value);
        ReloadLevel();
    }
}

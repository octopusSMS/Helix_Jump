using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonScript : MonoBehaviour
{
    public Game Game;
    public Button Button;

    private void Update()
    {
        Button.onClick.AddListener(Game.ReloadLevel);
    }
}

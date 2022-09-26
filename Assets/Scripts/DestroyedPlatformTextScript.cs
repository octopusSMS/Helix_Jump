using UnityEngine;
using UnityEngine.UI;

public class DestroyedPlatformTextScript : MonoBehaviour
{
    public Game Game;
    public Text Text;

    private void Update()
    {
        Text.text = "Destroyed platforms -  " + (Game.DestroyPlatformNumber).ToString();
    }
}

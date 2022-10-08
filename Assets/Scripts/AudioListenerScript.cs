using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
    [Min(0)]
    public float Volume;

    private void Update()
    {
        AudioListener.volume = Volume;
    }
}

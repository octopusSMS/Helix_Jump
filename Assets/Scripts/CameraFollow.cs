using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    public Vector3 PlatformToCameraOfset;
    public float Speed;

    void Update()
    {
        if (Player.CurrentPlatform == null) return;

        Vector3 targetPosition = Player.CurrentPlatform.transform.position+PlatformToCameraOfset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }
}

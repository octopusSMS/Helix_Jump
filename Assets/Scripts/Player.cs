using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    private AudioSource audioSource;

    public Platform CurrentPlatform;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        audioSource.Play();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

   
}

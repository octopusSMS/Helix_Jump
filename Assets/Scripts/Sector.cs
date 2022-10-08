using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public float BreakSpeed;

    private AudioSource _audio;

    private void Awake()
    {
        UpdateMaterial();     
        _audio = GetComponent<AudioSource>();
    }

    private void UpdateMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(-normal, Vector3.up);
        if (dot < 0.7) return;



        if (IsGood)
        {
            if (player.Rigidbody.velocity.y < -BreakSpeed)
            {
                DestroySector();
                _audio.Play();
            }
            player.Bounce(); 
        }
        else
            player.Die();

        
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }

    private void DestroySector()
    {
        Rigidbody Rigidbody = GetComponent<Rigidbody>();
        Collider Collider = GetComponent<MeshCollider>();

        Destroy(Collider);
        Rigidbody.constraints = RigidbodyConstraints.None;
        Rigidbody.useGravity = true;

        Game Game = FindObjectOfType<Game>();
        Game.DestroyPlatformNumber++;
    }
}

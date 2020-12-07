using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    /// <summary>
    /// Just in charge of shooting and playing a sound
    /// </summary>

    public Transform projectilePrefab;
    public Transform gunBarrel;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Shoot()
    {
        //shoot this projectile and play the sound
        Instantiate(projectilePrefab, gunBarrel.position, gunBarrel.rotation);
        audioSource.Play();
    }
}

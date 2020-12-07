using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    /// <summary>
    /// manage respawning for the player- weird huh?
    /// </summary>

    //current respawn positioina nd rotation
    Vector3 respawnPosition = Vector3.zero;
    Quaternion respawnRotation= Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if we go into an area with a tag pf respawn, set the new respawn pos and rot to those
        if (other.tag == "Respawn")
        {
            respawnPosition = other.transform.position;
            respawnRotation = other.transform.rotation;
        }
    }

    public void Respawn()
    {
        //if we have an audio source play it
        var sound = GetComponent<AudioSource>();
        if (sound != null)
        {
            sound.Play();
        }
        var cc = GetComponent<CharacterController>();
        cc.enabled = false;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
        cc.enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    //what type of pickup
    public enum PickUpType {health, battery };
    public PickUpType type = PickUpType.health;

    [Tooltip("How much will this pack give")]
    public float amount = 100f;

    //will it respawn?
    public bool willRespawn = false;
    public float respawnTime = 10f;

    //movement stuff
    float yOffset = 0f;
    Vector3 startPos = Vector3.zero;
    float magnitude = 0.5f;
    float frequency = 2f;
    float rotatespeed = 180f;

    //the audio source to play a sound when we pick up
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position + new Vector3(0,magnitude,0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        yOffset = Mathf.Sin(Time.time * frequency) * magnitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
        transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //see if it is the player and give him health
        if (other.tag == "Player")
        {
            switch (type)
            {
                case PickUpType.health:
                    //get the damage script
                    var damageScript = other.GetComponent<Damage>();
                    damageScript.GiveHealth(amount);
                    StartCoroutine(Collected());
                    break;
                case PickUpType.battery:
                    //get the damage script
                    var playerShootingScript = other.GetComponent<PlayerShootingScript>();
                    playerShootingScript.RechargeBattery(amount);
                    StartCoroutine(Collected());
                    break;
                default:
                    break;
            }
            
        }
    }
    
    IEnumerator Collected()
    {
        audioSource.Play();
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = false;
        }
        yield return new WaitForSeconds(respawnTime);
        if (!willRespawn)
        {
            Destroy(gameObject);
            yield return null;
        }
        //re enable it
        collider.enabled = true;
        foreach (var renderer in renderers)
        {
            renderer.enabled = true;
        }
    }
}

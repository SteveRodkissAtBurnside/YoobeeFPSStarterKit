using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    /// <summary>
    /// Kill the player if he goes in it
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //tell the player they need to respawn
            other.GetComponent<PlayerRespawnManager>().Respawn();
        }
    }

}

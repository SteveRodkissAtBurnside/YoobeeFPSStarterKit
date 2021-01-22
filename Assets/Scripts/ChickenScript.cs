using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{

    public Transform explosionPrefab;
    Transform player;

    public void Explode()
    {
        //instantiate the damaging explosion!
        Instantiate(explosionPrefab, transform.position, explosionPrefab.rotation);
        Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        //see if we are close enough to the player to explode!
        float d = Vector3.Distance(player.position, transform.position);
        if (d<2f)
        {
            //explode!!!
            Explode();
        }
    }


}

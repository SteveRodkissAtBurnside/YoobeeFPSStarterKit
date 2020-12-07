using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTurret : MonoBehaviour
{

    //the target
    Transform target;

    [Tooltip("What methods to run if this turret is to shoot")]
    public UnityEvent shootEvent;

    [Range(0f,5f)]
    public float fireRate = 1f;
    private float fireDelay = 1f;
    private float fireTimer = 0f;
    [Range(5, 20f)]
    [Tooltip("The range in metres of the turret")]
    public float range = 10f;

    //the explosion particle system
    public Transform explosionParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fireDelay = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelay && AimingAtPlayer())
        {
            //invoke any events that we hook up to this for shooting
            shootEvent.Invoke();
            //reset timer
            fireTimer = 0f;
        }

        //now deal with turning around
        if (CanSeePlayer())
        {
            TurnToFace(target.position);
        }
    }

    //will check player is not hiding out of sight or out of range
    bool CanSeePlayer()
    {
        //get a ray to the player
        Vector3 direction = (target.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            //check that the player is the first reaycast hit or we cant see player;
            return hit.collider.tag == "Player";
        }
        return false;
    }

    void TurnToFace(Vector3 position)
    {
        //slowly turn to face the position
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(position - transform.position), 36f * Time.deltaTime);
    }

    bool AimingAtPlayer()
    {
        //cast a ray and see if it hit the player
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            //we hit something!
            if (hit.collider.tag == "Player")
            {
                //its the player
                return true;
            }
        }
        return false;
    }


    public void Die()
    {
        //this will be called by the damage event
        //create the explosion and then destroy us
        Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}

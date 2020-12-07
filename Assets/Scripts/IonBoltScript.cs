using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class IonBoltScript : MonoBehaviour
{
    /// <summary>
    /// A slow moving projectile that causes damage when it hits something
    /// </summary>
    Rigidbody rb;

    public float speed = 10f;

    float boltDamage = 50f;

    public Transform explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 4f);    //destroy after four seconds anyway
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //when it hits something
        var dmg = collision.collider.GetComponent<Damage>();
        if (dmg != null)
        {
            //the object has a damage script, damage it.
            dmg.TakeDamage(boltDamage);
        }
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}

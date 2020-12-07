using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{


    //a fast raycasting laser
    public float Speed = 200f;
    Vector3 LastPos;
    public float LifeSpan = 2f;
    float Age = 0f;
    public float LaserDamage = 10f;

    //sparks if the laser hit
    public GameObject HitParticleSystem;

    // Use this for initialization
    void Start()
    {
        LastPos = transform.position;
    }
	
    // Update is called once per frame
    void Update()
    {
        Age += Time.deltaTime;
        if (Age > LifeSpan)
        {
            //destroy the object
            Destroy(gameObject);
            return;
        }
        LastPos = transform.position;
        transform.position += transform.forward * Speed * Time.deltaTime;
        //look for anything between lastpos and currentpos
        Vector3 dir = transform.position - LastPos;
        Ray ray = new Ray(LastPos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dir.magnitude))
        {
            //Ouch
            Instantiate(HitParticleSystem, hit.point, Quaternion.identity);
            var dmg = hit.collider.gameObject.GetComponent<Damage>();
            if (dmg != null)
            {
                dmg.TakeDamage(10f);
            }
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float fuseTime = 2f;
    public float range = 10f;
    public float damage = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        //count down then explode
        yield return new WaitForSeconds(fuseTime);
        //now explode
        Instantiate(explosionPrefab,transform.position,Quaternion.identity);
        DamageInRange(range);
        Destroy(gameObject);
    }

    void DamageInRange(float range)
    {
        //damage all the objects with damage scripts in the given range
        Collider[] colliders = Physics.OverlapSphere(transform.position,range);
        foreach (var collider in colliders)
        {
            //check if it has a damage script
            var damageable = collider.GetComponent<Damage>();
            if(damageable)
            {
                //it has a damage script
                float totalDamage = damage * (1f- Vector3.Distance(transform.position,collider.transform.position)/range);
                damageable.TakeDamage(totalDamage);
            }
        }
    }

}

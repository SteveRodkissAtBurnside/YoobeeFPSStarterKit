using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAllInRange : MonoBehaviour
{
    /// <summary>
    /// find everything in the given range and if it has a damage script do damage based on distance
    /// </summary>
    /// 



    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);
        foreach (var collider in colliders)
        {
            Debug.Log($"Damaging the object: {collider.gameObject.name}");
            //get damage script
            var damage = collider.GetComponent<Damage>();
            if (damage != null)
            {
                //we can damage it
                damage.TakeDamage(1000f);
            }
        }
    }
}

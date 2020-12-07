using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{

    public float startingHealth = 100f;
    private float health;

    //what to do when health is zero
    public UnityEvent deathEvent;

 

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //we are deed
            deathEvent.Invoke();
            health = startingHealth;
        }
    }

    public float GetHealthPercent()
    {
        return (health / startingHealth) * 100f;
    }

    public void GiveHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, startingHealth);
    }


}

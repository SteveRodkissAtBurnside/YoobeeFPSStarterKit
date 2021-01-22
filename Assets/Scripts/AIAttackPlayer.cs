using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackPlayer : MonoBehaviour
{

    NavMeshAgent ai;
    Transform playerTransform;
    //chicken animator- set Chasing as true or false;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Think());
        animator.SetBool("Chasing", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Think()
    {
        while (true)
        {
            ai.SetDestination(playerTransform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }

}

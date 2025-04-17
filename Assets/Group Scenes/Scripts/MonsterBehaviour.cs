using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterBehavior : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private bool isFrozen = true; // Start frozen
    public Transform player;
    public float detectionRadius = 10f;
    public float attackRange = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Disable the animator and stop the agent's movement for the first 30 seconds
        animator.enabled = false;
        agent.isStopped = true;

        // Start the coroutine to unfreeze the monster after 30 seconds
        StartCoroutine(UnfreezeAfterDelay(60f));
    }

    void Update()
    {
        if (isFrozen)
        {
            // Do nothing (the monster is frozen and can't move or animate)
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            animator.SetTrigger("attack");
            agent.isStopped = true;
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            animator.SetBool("run", true);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    IEnumerator UnfreezeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified time (30 seconds)
        
        // After the delay, reactivate the animator and allow the monster to move
        animator.enabled = true;
        isFrozen = false;  // The monster is no longer frozen
    }

    public void SetFrozen(bool frozen)
    {
        isFrozen = frozen;
        animator.enabled = !frozen;
        agent.isStopped = frozen;
    }
}
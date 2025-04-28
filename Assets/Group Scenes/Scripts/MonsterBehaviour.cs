using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterBehavior : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    public Transform player;
    public float attackRange = 2f;
    public float detectionRadius = 10f;
    public float explorationRadius = 20f;
    public float freezeDelay = 5f; // How long monster is frozen at start

    private bool isFrozen = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        animator.enabled = false;
        agent.isStopped = true;

        StartCoroutine(UnfreezeAfterDelay(freezeDelay));
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;

        if (isFrozen)
        {
            agent.isStopped = true;
            animator.speed = 0f;
            return;
        }

        agent.isStopped = false;
        animator.speed = 1f;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            WanderRandomly();
        }
    }

    private void AttackPlayer()
    {
        agent.isStopped = true; // Stop moving when attacking
        animator.SetTrigger("attack");
    }

    private void ChasePlayer()
    {
        animator.SetBool("run", true);
        agent.SetDestination(player.position);
    }

    private void WanderRandomly()
    {
        animator.SetBool("run", false);

        if (!agent.hasPath || agent.remainingDistance < 0.5f)
        {
            Vector3 randomDirection = Random.insideUnitSphere * explorationRadius;
            randomDirection += transform.position;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, explorationRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }

    IEnumerator UnfreezeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
        isFrozen = false;
    }

    public void SetFrozen(bool frozen)
    {
        isFrozen = frozen;
    }

    public bool IsFrozen()
    {
        return isFrozen;
    }
}

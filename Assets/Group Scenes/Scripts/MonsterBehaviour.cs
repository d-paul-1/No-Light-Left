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
    public float freezeDelay = 30f; // How long monster is frozen after teleportation

    private bool isFrozen = true;
    private bool allowExternalUnfreeze = false; // Block external unfreezing until timer ends

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        animator.enabled = false;
        agent.isStopped = true;

        Debug.Log("Monster initialized, waiting for teleport to start freeze.");
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;

        if (isFrozen)
        {
            agent.isStopped = true;
            animator.speed = 0f;
            Debug.Log("Monster is frozen. Not moving.");
            return;
        }

        agent.isStopped = false;
        animator.speed = 1f;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            Debug.Log("Monster is attacking player.");
            AttackPlayer();
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            Debug.Log("Monster is chasing player.");
            ChasePlayer();
        }
        else
        {
            Debug.Log("Monster is wandering randomly.");
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
                Debug.Log("Monster set new wander destination: " + hit.position);
            }
        }
    }

    // This coroutine will start when teleportation happens, starting the freeze delay
    public void StartFreezeDelay()
    {
        Debug.Log("Freeze delay started.");
        StartCoroutine(UnfreezeAfterDelay(freezeDelay));
    }

    IEnumerator UnfreezeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
        isFrozen = false;
        allowExternalUnfreeze = true;
        Debug.Log("Monster unfrozen. Starting behavior.");
    }

    public void SetFrozen(bool frozen)
    {
        if (!allowExternalUnfreeze && !frozen)
        {
            Debug.Log("External unfreeze blocked — still within initial freeze delay.");
            return;
        }

        isFrozen = frozen;
        Debug.Log("SetFrozen called. Frozen: " + frozen);
    }

    public bool IsFrozen()
    {
        return isFrozen;
    }
}

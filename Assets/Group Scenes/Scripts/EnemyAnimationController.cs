using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public Transform player;
    public float attackRange = 2f;
    public float detectionRadius = 10f;

    private float delayDuration = 60f;
    private float startTime;
    private bool hasStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        startTime = Time.time;

        animator.enabled = false; // 🔇 Disable animations during delay
        agent.isStopped = true;   // ⛔ Don't move
    }

    void Update()
    {
        if (!hasStarted && Time.time >= startTime + delayDuration)
        {
            animator.enabled = true; // ✅ Enable animations after delay
            hasStarted = true;
        }

        if (!hasStarted)
        {
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
        else if (agent.remainingDistance > 0.5f && !agent.isStopped)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
}
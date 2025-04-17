using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomPath : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float explorationRadius = 20f;
    public Transform player;

    private NavMeshAgent agent;
    private float delayDuration = 60f;
    private float startTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startTime = Time.time;

        if (agent.isOnNavMesh)
        {
            ExploreRandomly(); // Optional: can skip if you don't want it moving before delay
        }
        else
        {
            Debug.LogError("Agent is not on a valid NavMesh!");
        }
    }

    void Update()
    {
        if (!agent.isOnNavMesh || Time.time < startTime + delayDuration)
        {
            return;
        }

        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            ExploreRandomly();
        }
    }

    void ExploreRandomly()
    {
        Vector3 randomDirection = Random.insideUnitSphere * explorationRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, explorationRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explorationRadius);
    }
}
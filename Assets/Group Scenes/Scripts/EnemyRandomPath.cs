using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomPath : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float explorationRadius = 20f;
    public Transform player;

    private NavMeshAgent agent;
    private MonsterBehavior monsterBehavior; // << Add reference to MonsterBehavior

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        monsterBehavior = GetComponent<MonsterBehavior>(); // << Get the script
    }

    void Update()
    {
        if (!agent.isOnNavMesh || monsterBehavior == null || monsterBehavior.IsFrozen()) return;

        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }
        else if (!agent.hasPath || agent.remainingDistance < 0.5f)
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
}

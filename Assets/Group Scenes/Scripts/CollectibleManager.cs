using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;
    public int collectedCount = 0;
    public int targetCount = 3;
    public bool goalReached = false;
    public GameObject rewardPrefab; // Assign in Inspector
    public float spawnDistance = 1.5f; // Distance in front of camera

    public void start(){
        rewardPrefab.SetActive(false);
    }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementCount()
    {
        collectedCount++;

        Debug.Log("Collected: " + collectedCount);

        if (collectedCount >= targetCount && !goalReached)
        {
            goalReached = true;
            Debug.Log("Goal Reached!");
            SpawnReward();
        }
    }

    void SpawnReward()
    {
        if (rewardPrefab == null)
        {
            Debug.LogWarning("Reward Prefab not assigned.");
            return;
        }

        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            Vector3 spawnPosition = mainCam.transform.position + mainCam.transform.forward * spawnDistance;
            Instantiate(rewardPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Main Camera not found.");
        }
    }
}

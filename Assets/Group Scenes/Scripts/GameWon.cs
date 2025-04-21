using UnityEngine;

public class GameWon : MonoBehaviour
{
    public GameObject objectToSpawn;   // Prefab to spawn
    public float spawnDistance = 1.5f; // How far in front of player to spawn
    public bool spawnOnce = true;

    private bool hasSpawned = false;


    private void OnTriggerEnter(Collider other)
    {
        // You can change this tag if your player has a different one
        if (!other.CompareTag("Player") || (spawnOnce && hasSpawned))
            return;

        Camera mainCam = Camera.main;
        if (mainCam != null && objectToSpawn != null)
        {
            objectToSpawn.SetActive(true);
            Vector3 spawnPosition = mainCam.transform.position + mainCam.transform.forward * spawnDistance;
            Quaternion spawnRotation = Quaternion.LookRotation(-mainCam.transform.forward); // faces the player
            Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            hasSpawned = true;
        }
    }
}

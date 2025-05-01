using UnityEngine;

using System.Collections.Generic;

public class DollHider : MonoBehaviour
{
    public GameObject objectToHide;
    public Transform[] spawnPoints;
    public int numberToSpawn = 3;

    void Start()
    {
        HideDolls();
    }

    void HideDolls()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
            indices.Add(i);

        // Shuffle the indices
        for (int i = 0; i < indices.Count; i++)
        {
            int rand = Random.Range(i, indices.Count);
            int temp = indices[i];
            indices[i] = indices[rand];
            indices[rand] = temp;
        }

        // Spawn dolls with rotation and interaction
        for (int i = 0; i < numberToSpawn; i++)
        {
            Quaternion uprightRotation = Quaternion.Euler(-90f, 0f, 0f);
            GameObject doll = Instantiate(objectToHide, spawnPoints[indices[i]].position, uprightRotation);

            // Ensure it has a collider
            if (doll.GetComponent<Collider>() == null)
            {
                doll.AddComponent<BoxCollider>(); // Or MeshCollider if needed
            }

            // Add Rigidbody for gravity
            Rigidbody rb = doll.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = doll.AddComponent<Rigidbody>();
                rb.useGravity = true;
                rb.mass = 1f;
            }

            // Add XRGrabInteractable
            if (doll.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() == null)
            {
                doll.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            }
        }
    }
}

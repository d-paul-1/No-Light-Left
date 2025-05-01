using UnityEngine;
using System.Collections.Generic;

public class DollActivator : MonoBehaviour
{
    public List<GameObject> allDolls; // Assign your 9 dolls here in the inspector
    public int dollsToActivate = 9;

    void Start()
    {
        HideAllDolls();
        ActivateRandomDolls();
    }

    void HideAllDolls()
    {
        foreach (var doll in allDolls)
        {
            doll.SetActive(false);
        }
    }

    void ActivateRandomDolls()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < allDolls.Count; i++)
            indices.Add(i);

        // Shuffle indices
        for (int i = 0; i < indices.Count; i++)
        {
            int rand = Random.Range(i, indices.Count);
            int temp = indices[i];
            indices[i] = indices[rand];
            indices[rand] = temp;
        }

        // Activate the first N dolls
        for (int i = 0; i < dollsToActivate; i++)
        {
            GameObject selectedDoll = allDolls[indices[i]];
            selectedDoll.SetActive(true);

            // OPTIONAL: Customize per-position logic
            Debug.Log("Activated Doll: " + selectedDoll.name);
        }
    }
}

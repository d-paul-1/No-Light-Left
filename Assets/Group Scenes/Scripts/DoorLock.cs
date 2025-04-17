using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorUnlockHinge : MonoBehaviour
{
    [Header("Hinge Settings")]
    public HingeJoint doorHinge;
    public bool unlockOnInsert = true;

    [Header("Socket Settings")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor keySocket;
    public string keyTag = "Key";

    private bool isUnlocked = false;

    void OnEnable()
    {
        keySocket.selectEntered.AddListener(OnKeyInserted);
        keySocket.selectExited.AddListener(OnKeyRemoved);
    }

    void OnDisable()
    {
        keySocket.selectEntered.RemoveListener(OnKeyInserted);
        keySocket.selectExited.RemoveListener(OnKeyRemoved);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(keyTag) && !isUnlocked)
        {
            Debug.Log("Key inserted. Door unlocked.");
            isUnlocked = true;
            UnlockDoor();
        }
    }

    private void OnKeyRemoved(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(keyTag) && unlockOnInsert == false)
        {
            Debug.Log("Key removed. Door locked.");
            isUnlocked = false;
            LockDoor();
        }
    }

    private void UnlockDoor()
    {
        if (doorHinge != null)
        {
            JointLimits limits = doorHinge.limits;
            limits.min = -90f;
            limits.max = 90f;
            doorHinge.limits = limits;
            doorHinge.useLimits = true;
            doorHinge.useSpring = false;
        }
    }

    private void LockDoor()
    {
        if (doorHinge != null)
        {
            JointLimits limits = doorHinge.limits;
            limits.min = 0f;
            limits.max = 0f;
            doorHinge.limits = limits;
            doorHinge.useLimits = true;
            doorHinge.useSpring = false;
        }
    }
}
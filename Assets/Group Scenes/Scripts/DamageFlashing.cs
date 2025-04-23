using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FlashingMessageTrigger : MonoBehaviour
{
    public GameObject messageObject;         // UI panel/image
    private CanvasGroup canvasGroup;

    public float flashSpeed = 1f;            // Speed of flashing
    [Range(0f, 1f)]
    public float maxAlpha = 0.6f;            // Maximum transparency

    private Coroutine flashingCoroutine;
    private bool isPlayerInside = false;

    void Start()
    {
        messageObject.SetActive(false);
        canvasGroup = messageObject.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
            canvasGroup.alpha = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            messageObject.SetActive(true);

            if (flashingCoroutine == null)
                flashingCoroutine = StartCoroutine(FlashMessage());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            if (flashingCoroutine != null)
            {
                StopCoroutine(flashingCoroutine);
                flashingCoroutine = null;
            }

            if (canvasGroup != null)
                canvasGroup.alpha = 0f;

            messageObject.SetActive(false);
        }
    }

    IEnumerator FlashMessage()
    {
        float t = 0f;
        while (isPlayerInside)
        {
            if (canvasGroup != null)
                canvasGroup.alpha = Mathf.Abs(Mathf.Sin(t * flashSpeed)) * maxAlpha;

            t += Time.deltaTime;
            yield return null;
        }

        if (canvasGroup != null)
            canvasGroup.alpha = 0f;
    }
}
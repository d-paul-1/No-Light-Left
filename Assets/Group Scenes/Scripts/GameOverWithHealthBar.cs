using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;                  // UI Slider for health
    public float maxHealth = 100f;
    public float damageRate = 2f;
    public GameObject buttons;
    private float currentHealth;
    private bool isTakingDamage = false;
    private bool isDead = false;
    public GameObject Monster;
    public GameObject flashingImage;
    public GameObject locomotion;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (isTakingDamage)
        {
            Debug.Log("Taking damage"+currentHealth);
            currentHealth -= damageRate * Time.deltaTime;
            currentHealth = Mathf.Max(currentHealth, 0);
            Debug.Log("Current Health: " + currentHealth);
            UpdateHealthBar();
        }

         if (currentHealth <= 0)
            {
                HandleDeath();
                Monster.SetActive(false);
                locomotion.SetActive(false);
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Edit this condition for monster attacking
        {
            isTakingDamage = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Maybe this one too?
        {
            isTakingDamage = false;
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            Debug.Log("HEalth BAr works");
            healthBar.value = currentHealth / maxHealth;
            Debug.Log("Updating Health Bar: " + (currentHealth / maxHealth));
        }
    }

    void HandleDeath()
    {
        isDead = true;
        isTakingDamage = false;
        buttons.SetActive(true);

        if (buttons != null)
        {
            buttons.SetActive(true);
            flashingImage.SetActive(false);
        }

        // Optional: Disable player input, movement, or play death animation here
    }
}
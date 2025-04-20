using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;                  // UI Slider for health
    public float maxHealth = 100f;
    public float damageRate = 20f;
    public GameObject buttons;
    private float currentHealth;
    private bool isTakingDamage = false;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

    }

    void Update()
    {
        if (isTakingDamage)
        {
            currentHealth -= damageRate * Time.deltaTime;
            currentHealth = Mathf.Max(currentHealth, 0);
            UpdateHealthBar();
        }

         if (currentHealth <= 0)
            {
                HandleDeath();
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTakingDamage = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTakingDamage = false;
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }

    void HandleDeath()
    {
        isDead = true;
        isTakingDamage = false;
        //buttons.SetActive(true);


        if (buttons != null)
        {
            buttons.SetActive(true);
        }

        // Optional: Disable player input, movement, or play death animation here
    }
}
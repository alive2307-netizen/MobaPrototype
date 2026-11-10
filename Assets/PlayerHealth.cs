using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Игрок получил урон. Здоровье: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Игрок лечится. Здоровье: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("ИГРОК ПОГИБ! Поражение.");
        // Вызываем поражение через GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseGame();
        }
    }
}
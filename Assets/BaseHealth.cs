using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public bool isEnemyBase = false; // Галочка, чтобы понять, чья это база

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " получила урон. Осталось: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Если это база врага — мы победили
        if (isEnemyBase)
        {
            Debug.Log("ПОБЕДА!");
            if (GameManager.Instance != null) GameManager.Instance.WinGame();
        }
        // Если это наша база — мы проиграли
        else
        {
            Debug.Log("ПОРАЖЕНИЕ!");
            if (GameManager.Instance != null) GameManager.Instance.LoseGame();
        }
    }
}
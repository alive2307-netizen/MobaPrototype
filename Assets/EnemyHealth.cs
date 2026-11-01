using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 30f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Враг побежден!");
        Destroy(gameObject);
    }
}
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        // 1. Если попали во врага (по тегу)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Уничтожаем снаряд
        }
        // 2. Если попали в базу врага (по имени объекта)
        else if (collision.gameObject.name == "EnemyBase")
        {
            BaseHealth baseHealth = collision.gameObject.GetComponent<BaseHealth>();
            if (baseHealth != null)
            {
                baseHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Уничтожаем снаряд
        }
    }
}
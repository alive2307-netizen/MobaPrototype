using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        // 1. Попали во врага
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null) enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        // 2. Попали в базу врага
        else if (collision.gameObject.name == "EnemyBase")
        {
            BaseHealth baseHealth = collision.gameObject.GetComponent<BaseHealth>();
            if (baseHealth != null) baseHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        // 3. Попали в СВОЕГО крестьянина (Штраф)
        else if (collision.gameObject.CompareTag("Peasant"))
        {
            PeasantHealth peasant = collision.gameObject.GetComponent<PeasantHealth>();
            if (peasant != null) peasant.TakeDamage(1);
            
            // Штраф игроку
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerShoot shootScript = player.GetComponent<PlayerShoot>();
                if (shootScript != null)
                {
                    shootScript.ApplyPenalty(3f); // Штраф 3 секунды
                }
            }
            
            Destroy(gameObject);
        }
    }
}
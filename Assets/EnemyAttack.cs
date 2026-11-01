using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    void OnCollisionStay(Collision collision)
    {
        // Если враг столкнулся с нашей базой
        if (collision.gameObject.name == "PlayerBase")
        {
            // Проверяем кулдаун атаки
            if (Time.time >= nextAttackTime)
            {
                BaseHealth baseHealth = collision.gameObject.GetComponent<BaseHealth>();
                if (baseHealth != null)
                {
                    baseHealth.TakeDamage(damage);
                }
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
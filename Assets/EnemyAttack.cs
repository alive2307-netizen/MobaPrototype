using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 5f;
    public float attackCooldown = 1f;
    public float attackRange = 2.5f; // Радиус атаки (чуть меньше, чем радиус обнаружения)
    
    private float nextAttackTime = 0f;
    private Transform playerBase;
    private Transform playerTarget;

    void Start()
    {
        GameObject baseObj = GameObject.Find("PlayerBase");
        if (baseObj != null) playerBase = baseObj.transform;
    }

    void Update()
    {
        if (playerTarget == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) playerTarget = p.transform;
        }

        if (Time.time < nextAttackTime) return;

        // 1. Приоритет — атака игрока, если он близко
        if (playerTarget != null)
        {
            float distToPlayer = Vector3.Distance(transform.position, playerTarget.position);
            if (distToPlayer <= attackRange)
            {
                PlayerHealth playerHealth = playerTarget.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    nextAttackTime = Time.time + attackCooldown;
                    return; // Выходим, чтобы не бить базу в этот же кадр
                }
            }
        }

        // 2. Если игрока нет рядом, бьем базу
        if (playerBase != null)
        {
            float distToBase = Vector3.Distance(transform.position, playerBase.position);
            if (distToBase <= attackRange)
            {
                BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
                if (baseHealth != null)
                {
                    baseHealth.TakeDamage(damage);
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }
}
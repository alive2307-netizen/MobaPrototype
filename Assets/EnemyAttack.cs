using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 5f;
    public float attackCooldown = 1f;
    public float attackRange = 3f; 
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
        // Ищем игрока, если еще не нашли
        if (playerTarget == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) playerTarget = p.transform;
        }

        // 1. Атака базы (если враг дошел до нее)
        if (playerBase != null)
        {
            float distToBase = Vector3.Distance(transform.position, playerBase.position);
            if (distToBase <= attackRange && Time.time >= nextAttackTime)
            {
                BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
                if (baseHealth != null) baseHealth.TakeDamage(damage);
                nextAttackTime = Time.time + attackCooldown;
                return; // Если бьем базу, не бьем игрока в этот кадр
            }
        }

        // 2. Атака игрока (если игрок подошел близко к врагу)
        if (playerTarget != null)
        {
            float distToPlayer = Vector3.Distance(transform.position, playerTarget.position);
            if (distToPlayer <= attackRange && Time.time >= nextAttackTime)
            {
                PlayerHealth playerHealth = playerTarget.GetComponent<PlayerHealth>();
                if (playerHealth != null) playerHealth.TakeDamage(damage);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
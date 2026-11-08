using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 5f;
    public float attackCooldown = 1f;
    public float attackRange = 3f; 
    private float nextAttackTime = 0f;
    private Transform playerBase;

    void Start()
    {
        GameObject baseObj = GameObject.Find("PlayerBase");
        if (baseObj != null) playerBase = baseObj.transform;
    }

    void Update()
    {
        if (playerBase == null) return;

        float distance = Vector3.Distance(transform.position, playerBase.position);

        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            if (baseHealth != null)
            {
                baseHealth.TakeDamage(damage);
            }
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
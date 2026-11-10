using UnityEngine;

public class BaseHealing : MonoBehaviour
{
    public float healRadius = 4f;
    public float healAmount = 10f; // Сколько лечит в секунду
    public float healCooldown = 1f; // Как часто лечит
    private float nextHealTime = 0f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (distance <= healRadius && Time.time >= nextHealTime)
            {
                PlayerHealth health = player.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.Heal(healAmount);
                }
                nextHealTime = Time.time + healCooldown;
            }
        }
    }
}
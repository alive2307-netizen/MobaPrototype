using UnityEngine;
using UnityEngine.AI;

public class PeasantAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerBase;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject baseObj = GameObject.Find("PlayerBase");
        if (baseObj != null) playerBase = baseObj.transform;
    }

    void Update()
    {
        if (playerBase == null) return;

        // Идем к базе
        agent.SetDestination(playerBase.position);

        // Если крестьянин близко к базе — он скрывается
        float distance = Vector3.Distance(transform.position, playerBase.position);
        if (distance <= 2.5f)
        {
            Destroy(gameObject); // Исчезает
        }
    }
}
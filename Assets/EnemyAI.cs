using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Цель (база игрока)
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Ищем синюю базу на сцене по имени
        GameObject baseObj = GameObject.Find("PlayerBase");
        if (baseObj != null)
        {
            target = baseObj.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Враг постоянно движется к цели
            agent.SetDestination(target.position);
        }
    }
}
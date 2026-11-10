using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform playerBase;
    public Transform playerTarget;
    
    [Header("Detection")]
    public float detectRadius = 6f; // Радиус, в котором враг замечает игрока
    public float loseRadius = 8f;   // Радиус, при котором враг теряет игрока

    private NavMeshAgent agent;
    private bool isChasingPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject baseObj = GameObject.Find("PlayerBase");
        if (baseObj != null) playerBase = baseObj.transform;
    }

    void Update()
    {
        // Ищем игрока, если он еще не найден
        if (playerTarget == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) playerTarget = p.transform;
        }

        // Если база уничтожена, враг больше не нужен (или можно заставить его стоять)
        if (playerBase == null) return;

        if (playerTarget != null)
        {
            float distToPlayer = Vector3.Distance(transform.position, playerTarget.position);

            // Логика переключения цели
            if (!isChasingPlayer && distToPlayer <= detectRadius)
            {
                isChasingPlayer = true; // Начинаем преследование
            }
            else if (isChasingPlayer && distToPlayer > loseRadius)
            {
                isChasingPlayer = false; // Игрок убежал, возвращаемся к базе
            }
        }

        // Двигаемся к цели
        if (isChasingPlayer && playerTarget != null)
        {
            agent.SetDestination(playerTarget.position);
        }
        else if (playerBase != null)
        {
            agent.SetDestination(playerBase.position);
        }
    }
}
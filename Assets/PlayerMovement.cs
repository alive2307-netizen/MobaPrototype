using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem; // <-- Добавлено для нового Input System

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Безопасная проверка: если мыши нет (например, на телефоне), выходим
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
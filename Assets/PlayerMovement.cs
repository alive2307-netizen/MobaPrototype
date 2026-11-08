using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;
    
    [Header("Keyboard Movement")]
    public float wasdSpeed = 5f;
    private bool useKeyboard = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null || Keyboard.current == null) return;

        // 1. ВВОД С МЫШИ (Клик)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Включаем навигацию, если она была отключена для WASD
                agent.enabled = true; 
                useKeyboard = false;
                agent.SetDestination(hit.point);
            }
        }

        // 2. ВВОД С КЛАВИАТУРЫ (WASD)
        float x = 0f;
        float z = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) z = -1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;

        Vector3 inputDir = new Vector3(x, 0, z).normalized;

        // Если нажаты клавиши WASD
        if (inputDir.magnitude > 0.1f)
        {
            if (!useKeyboard)
            {
                useKeyboard = true;
                agent.enabled = false; // Отключаем NavMeshAgent, чтобы он не мешал
            }

            // Двигаем и поворачиваем персонажа
            transform.Translate(inputDir * wasdSpeed * Time.deltaTime, Space.World);
            transform.forward = Vector3.Slerp(transform.forward, inputDir, Time.deltaTime * 10f);
        }
        // Если клавиши отпущены и мы двигались на WASD
        else if (useKeyboard)
        {
            useKeyboard = false;
            agent.enabled = true; // Включаем навигацию обратно
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem; // <-- Добавлено

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float shootForce = 1000f;
    public float cooldown = 0.3f; 
    private float nextShotTime = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Безопасная проверка: если мыши нет, выходим
        if (Mouse.current == null) return;

        // Стреляем по правой кнопке мыши (новый Input System)
        if (Mouse.current.rightButton.wasPressedThisFrame && Time.time >= nextShotTime)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            Vector3 shootDirection = transform.forward; 
            
            if (Physics.Raycast(ray, out hit))
            {
                shootDirection = (hit.point - transform.position).normalized;
            }

            GameObject proj = Instantiate(projectilePrefab, transform.position + shootDirection, Quaternion.LookRotation(shootDirection));
            
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootDirection * shootForce);
            }
            
            Destroy(proj, 2f);
            nextShotTime = Time.time + cooldown;
        }
    }
}
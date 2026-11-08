using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float shootForce = 1000f;
    public float cooldown = 0.3f; 
    private float nextShotTime = 0f;
    private Camera mainCamera;
    private bool isPenalized = false;
    private float penaltyEndTime = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        // Проверяем, не закончился ли штраф
        if (isPenalized && Time.time >= penaltyEndTime)
        {
            isPenalized = false;
            Debug.Log("Штраф окончен. Можно стрелять!");
        }

        if (isPenalized) return; // Если штраф активен, не даем стрелять

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

    // Метод для применения штрафа
    public void ApplyPenalty(float penaltyDuration)
    {
        isPenalized = true;
        penaltyEndTime = Time.time + penaltyDuration;
        Debug.Log("Штраф! Вы не можете стрелять " + penaltyDuration + " секунд.");
    }
}
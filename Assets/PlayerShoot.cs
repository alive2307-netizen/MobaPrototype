using UnityEngine;

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
        // Если нажата ПКМ и кулдаун прошел
        if (Input.GetMouseButtonDown(1) && Time.time >= nextShotTime)
        {
            // 1. Создаем луч из камеры в точку клика
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 2. Вычисляем направление стрельбы
            Vector3 shootDirection = transform.forward; // По умолчанию вперед
            
            if (Physics.Raycast(ray, out hit))
            {
                // Если луч попал в пол, стреляем в сторону курсора
                shootDirection = (hit.point - transform.position).normalized;
            }

            // 3. Создаем снаряд
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
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Ссылка на снаряд
    public float shootForce = 1000f;

    void Update()
    {
        // Если нажата правая кнопка мыши (или можно поставить на клавишу)
        if (Input.GetMouseButtonDown(1)) 
        {
            // Создаем снаряд в позиции игрока
            GameObject proj = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
            
            // Находим Rigidbody у снаряда и толкаем его вперед
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * shootForce);
            }
            
            // Уничтожаем снаряд через 2 секунды, чтобы не засорять сцену
            Destroy(proj, 2f);
        }
    }
}
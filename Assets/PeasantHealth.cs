using UnityEngine;

public class PeasantHealth : MonoBehaviour
{
    public void TakeDamage(float amount)
    {
        // Уничтожаем крестьянина с одного попадания
        Destroy(gameObject);
        Debug.Log("Вы попали в своего! Штраф!");
    }
}
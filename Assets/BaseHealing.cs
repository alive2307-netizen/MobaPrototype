using UnityEngine;

public class BaseHealing : MonoBehaviour
{
    public float healRadius = 4f; 

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (distance <= healRadius)
            {
                Debug.Log("Игрок лечится у базы!");
            }
        }
    }
}
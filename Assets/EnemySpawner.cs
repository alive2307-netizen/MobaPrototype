using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 6f;
    public int maxEnemies = 4;
    private float nextSpawn = 0f;

    void Update()
    {
        // Если игра остановлена (победа/поражение), не спавним
        if (Time.timeScale == 0f) return;

        // Если прошло достаточно времени
        if (Time.time < nextSpawn) return;

        // Ограничиваем количество врагов на сцене
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;

        // Создаем врага
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        nextSpawn = Time.time + spawnInterval;
    }
}
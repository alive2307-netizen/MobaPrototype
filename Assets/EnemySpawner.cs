using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 6f;
    public int maxEnemies = 4;

    [Header("Spawn Points")]
    public Transform[] spawnPoints; // Массив наших точек

    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.timeScale == 0f) return;
        if (Time.time < nextSpawn) return;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;

        // Проверяем, что точки вообще есть
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            // Выбираем случайную точку из списка
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform chosenPoint = spawnPoints[randomIndex];

            // Создаем врага в выбранной точке
            Instantiate(enemyPrefab, chosenPoint.position, chosenPoint.rotation);
        }

        nextSpawn = Time.time + spawnInterval;
    }
}
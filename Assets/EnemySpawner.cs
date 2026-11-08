using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject peasantPrefab;
    public float spawnInterval = 6f;
    public int maxEnemies = 4;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.timeScale == 0f) return;
        if (Time.time < nextSpawn) return;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform chosenPoint = spawnPoints[randomIndex];

            // 50 на 50: либо враг, либо крестьянин
            if (Random.value > 0.5f && peasantPrefab != null)
            {
                Instantiate(peasantPrefab, chosenPoint.position, chosenPoint.rotation);
            }
            else if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, chosenPoint.position, chosenPoint.rotation);
            }
        }

        nextSpawn = Time.time + spawnInterval;
    }
}
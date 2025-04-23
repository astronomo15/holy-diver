using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || spawnPoints.Length == 0)
        {
            return;
        }

        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemyToSpawn = enemyPrefabs[randomEnemyIndex];
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
    }

    public void SetEnemyPrefabs(GameObject[] newPrefabs)
    {
        enemyPrefabs = newPrefabs;
    }

    public void SetSpawnPoints(Transform[] newSpawnPoints)
    {
        spawnPoints = newSpawnPoints;
    }

    public void SetSpawnInterval(float newInterval)
    {
        spawnInterval = Mathf.Max(0.1f, newInterval);
    }
}
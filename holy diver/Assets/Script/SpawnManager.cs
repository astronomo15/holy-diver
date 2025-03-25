using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject goodItemPrefab;
    public GameObject badItemPrefab;

    public float spawnXMin = -7f;  // Limite esquerdo
    public float spawnXMax = 7f;   // Limite direito
    public float spawnYMin = 3f;   // Limite inferior da área de spawn
    public float spawnYMax = 6f;   // Limite superior da área de spawn

    public float spawnRate = 2f;    // Tempo entre spawns
    public float badItemChance = 0.5f; // Chance de spawnar um item ruim (50%)

    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InvokeRepeating("SpawnItems", 0f, spawnRate);
    }

    public void SpawnItems()
    {
        // Spawn do item bom (sempre acontece)
        Vector3 spawnPos = new Vector3(Random.Range(spawnXMin, spawnXMax), Random.Range(spawnYMin, spawnYMax), 0);
        Instantiate(goodItemPrefab, spawnPos, Quaternion.identity);

        // Spawn do item ruim (com chance)
        if (Random.value < badItemChance)
        {
            Vector3 badSpawnPos = new Vector3(Random.Range(spawnXMin, spawnXMax), Random.Range(spawnYMin, spawnYMax), 0);
            Instantiate(badItemPrefab, badSpawnPos, Quaternion.identity);
        }
    }
}

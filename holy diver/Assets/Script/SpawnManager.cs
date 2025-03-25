using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject goodItemPrefab;
    public GameObject badItemPrefab;
    public Transform spawnArea;
    public static SpawnManager Instance;

    public float spawnXMin = -7f;
    public float spawnXMax = 7f;
    public float spawnY = 6f; // Posição no topo da tela

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnItems();
    }

    public void SpawnItems()
    {
        // Spawn do item bom
        Vector3 spawnPos = new Vector3(Random.Range(spawnXMin, spawnXMax), spawnY, 0);
        Instantiate(goodItemPrefab, spawnPos, Quaternion.identity);

        // 50% de chance de spawnar um item ruim
        if (Random.value < 0.5f)
        {
            Vector3 badSpawnPos = new Vector3(Random.Range(spawnXMin, spawnXMax), spawnY, 0);
            Instantiate(badItemPrefab, badSpawnPos, Quaternion.identity);
        }
    }
}
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject itemBomPrefab;
    public GameObject itemRuimPrefab;

    public float xMin = -5f; // Mínimo da área de spawn no eixo X
    public float xMax = 5f;  // Máximo da área de spawn no eixo X
    public float ySpawn = 6f; // Altura fixa onde os itens surgem

    public float tempoSpawnMin = 1f; // Tempo mínimo entre spawns
    public float tempoSpawnMax = 3f; // Tempo máximo entre spawns

    public bool ladoEsquerdo = true; // Define se este spawn é do Player 1 ou Player 2

    private void Start()
    {
        Invoke("SpawnItem", Random.Range(tempoSpawnMin, tempoSpawnMax));
    }

    private void SpawnItem()
    {
        float posX = Random.Range(xMin, xMax);
        Vector2 spawnPosition = new Vector2(posX, ySpawn);

        // Decide aleatoriamente qual item spawnar (50% de chance para cada)
        GameObject item = Random.value > 0.5f ? itemBomPrefab : itemRuimPrefab;
        Instantiate(item, spawnPosition, Quaternion.identity);

        // Chama o próximo spawn dentro do tempo definido
        Invoke("SpawnItem", Random.Range(tempoSpawnMin, tempoSpawnMax));
    }
}

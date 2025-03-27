using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject itemBomPrefab;
    public GameObject itemRuimPrefab;

    public float xMin = -5f; // M�nimo da �rea de spawn no eixo X
    public float xMax = 5f;  // M�ximo da �rea de spawn no eixo X
    public float ySpawn = 6f; // Altura fixa onde os itens surgem

    public float tempoSpawnMin = 1f; // Tempo m�nimo entre spawns
    public float tempoSpawnMax = 3f; // Tempo m�ximo entre spawns

    public bool ladoEsquerdo = true; // Define se este spawn � do Player 1 ou Player 2

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

        // Chama o pr�ximo spawn dentro do tempo definido
        Invoke("SpawnItem", Random.Range(tempoSpawnMin, tempoSpawnMax));
    }
}

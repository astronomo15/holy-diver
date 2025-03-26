using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject goodItemPrefab;
    public GameObject badItemPrefab;

    public float spawnXMin = -7f;  // Limite esquerdo da tela
    public float spawnXMax = 7f;   // Limite direito da tela
    public float spawnYMin = 3f;   // Limite inferior da área de spawn
    public float spawnYMax = 6f;   // Limite superior da área de spawn

    public float spawnInterval = 2f; // Intervalo entre spawn de itens

    public float itemDisappearTime = 4f; // Tempo para desaparecer os itens

    private List<Vector3> spawnedPositions = new List<Vector3>(); // Lista para verificar as posições já spawnadas

    public static SpawnManager Instance { get; internal set; }

    private void Start()
    {
        StartCoroutine(SpawnItemsRoutine());
    }

    // Corrotina que irá spawnar os itens
    private IEnumerator SpawnItemsRoutine()
    {
        while (true)
        {
            // Spawn de um bom item
            SpawnItem(goodItemPrefab);

            // Spawn de um mau item com chance
            if (Random.value < 0.5f)
            {
                SpawnItem(badItemPrefab);
            }

            // Aguarda o intervalo para o próximo spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Função para spawnar qualquer item (bom ou mau)
    public void SpawnItem(GameObject itemPrefab)
    {
        Vector3 spawnPos = GetValidSpawnPosition();  // Corrigindo o erro da variável não atribuída
        GameObject spawnedItem = Instantiate(itemPrefab, spawnPos, Quaternion.identity);

        // Após 4 segundos, destruir o item
        Destroy(spawnedItem, itemDisappearTime);
    }

    // Função para obter uma posição válida de spawn
    private Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPos = Vector3.zero;  // Inicializando a variável spawnPos
        bool validPosition = false;

        // Garante que a nova posição seja válida e não sobreponha objetos existentes
        while (!validPosition)
        {
            spawnPos = new Vector3(Random.Range(spawnXMin, spawnXMax), Random.Range(spawnYMin, spawnYMax), 0);

            // Verifica a distância mínima de spawn entre os objetos
            validPosition = true;
            foreach (Vector3 position in spawnedPositions)
            {
                if (Vector3.Distance(position, spawnPos) < 2f) // Distância mínima de 2 unidades
                {
                    validPosition = false;
                    break;
                }
            }
        }

        // Adiciona a posição ao histórico para verificar futuras colisões
        spawnedPositions.Add(spawnPos);

        return spawnPos;
    }
}

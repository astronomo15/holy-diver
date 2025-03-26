using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemBom;
    public GameObject itemRuim;
    public Transform spawnPoint;
    public float spawnRate = 1.5f;
    public float fallSpeed = 3f;

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        GameObject itemPrefab = Random.value > 0.5f ? itemBom : itemRuim;
        Vector3 spawnPos = new Vector3(Random.Range(-3f, 3f), spawnPoint.position.y, 0);
        GameObject newItem = Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        newItem.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -fallSpeed);
    }
}

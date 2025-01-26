using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float spawnRate;
    public float spawnAmount;
    public float spawnDelay;

    private Vector2 spawnArea;
    private bool canSpawn;

    void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        if (canSpawn == true)
        {
            StartCoroutine(SpawnBubbles());
            canSpawn = false;
        }
        
    }

    IEnumerator SpawnBubbles()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(bubblePrefab, SpawnArea(), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

    Vector2 SpawnArea()
    {
        spawnArea = new Vector2(Random.Range(-6f, 6f), Random.Range(-3.25f, -0.8f));
        return spawnArea;
    }
}

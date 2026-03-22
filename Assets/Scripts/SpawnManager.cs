using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs;

    private readonly float spawnRangeX = 15f;
    private readonly float spawnPositionZ = 25f;

    private readonly int delay = 2;
    private readonly int interval = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal), delay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, spawnPrefabs.Length);
        Vector3 spawnPosition = new(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        Instantiate(spawnPrefabs[randomAnimal], spawnPosition, spawnPrefabs[randomAnimal].transform.rotation);
    }
}

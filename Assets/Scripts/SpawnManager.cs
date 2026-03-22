using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs;

    private readonly float topSpawnRangeX = 15f;
    private readonly float topSpawnPositionZ = 25f;

    private readonly float sideSpawnRangeZ = 10f;
    private readonly float sideSpawnPositionX = 25f;

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
        bool isSpawnTop = Random.Range(1, 3) % 2 == 0;

        int randomAnimal = Random.Range(0, spawnPrefabs.Length);
        if (isSpawnTop)
        {
            Vector3 spawnPosition = new(Random.Range(-topSpawnRangeX, topSpawnRangeX), 0, topSpawnPositionZ);

            Instantiate(spawnPrefabs[randomAnimal], spawnPosition, spawnPrefabs[randomAnimal].transform.rotation);
        }
        else
        {
            // Position
            bool isLeftSide = Random.Range(1, 3) % 2 == 0;
            int sideSpawnRangeZOffset = 2;
            Vector3 spawnPosition = new(isLeftSide ? -sideSpawnPositionX : sideSpawnPositionX, 0, Random.Range(sideSpawnRangeZOffset, sideSpawnRangeZOffset + sideSpawnRangeZ));

            // Animal Rotation
            Vector3 currentEuler = spawnPrefabs[randomAnimal].transform.rotation.eulerAngles;
            float targetY = isLeftSide ? 90f : -90f;
            Quaternion spawnRotation = Quaternion.Euler(currentEuler.x, targetY, currentEuler.z);

            Instantiate(spawnPrefabs[randomAnimal], spawnPosition, spawnRotation);
        }
    }
}

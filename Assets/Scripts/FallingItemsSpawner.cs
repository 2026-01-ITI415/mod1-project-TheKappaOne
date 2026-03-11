using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject[] fallingPrefabs;   // good and bad prefabs
    public float objectDropDelay = 2f;
    public float spawnRange = 15f;
    public float spawnHeight = 15f;


    void Start()
    {
        // Start dropping objects
        Invoke("DropObject", 2f);
    }

    void DropObject()
    {
        // Pick a random prefab from the array
        int index = Random.Range(0, fallingPrefabs.Length);
        GameObject fallingObject = Instantiate(fallingPrefabs[index]);

        // Give it a random position above the play area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            spawnHeight,
            Random.Range(-spawnRange, spawnRange)
        );

        fallingObject.transform.position = spawnPosition;

        // Drop the next object after a delay
        Invoke("DropObject", objectDropDelay);
    }
}
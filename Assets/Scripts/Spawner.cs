using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs; // Array of prefabs to spawn
    [SerializeField]
    public float spawnDelay = 3f; // Time delay between spawns

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObjects());
    }


    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Choose a random prefab from the array
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            // X position to spawn the object
            float xPos = 16f;

            // Spawn the object at the chosen position
            Instantiate(prefabToSpawn, new Vector3(xPos, transform.position.y, transform.position.z), Quaternion.identity);

            // Wait for the specified delay before spawning the next object
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}

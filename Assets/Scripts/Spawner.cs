using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs; // Array of prefabs to spawn
    [SerializeField]
    public float spawnDelay; // Time delay between spawns

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 3f;
        // Start the spawning coroutine
        StartCoroutine(SpawnObjects());
    }


    IEnumerator SpawnObjects()
    {
        // Wait for 3 seconds before starting to spawn objects
        yield return new WaitForSeconds(3f);

        float timer = 0f;
        while (true)
        {
            // Choose a random prefab from the array
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            // X position to spawn the object
            float xPos = 16f;

            // Spawn the object at the chosen position
            Instantiate(prefabToSpawn, new Vector3(xPos, transform.position.y, transform.position.z), Quaternion.identity);

            // Increase the timer by the spawn delay
            timer += spawnDelay;

            // Check if a minute has passed, and adjust the spawn delay if necessary
            if (timer >= 60f)
            {
                spawnDelay = Mathf.Min(spawnDelay * 0.75f, 1.2f );
                //spawnDelay *= 0.5f; // Reduce the spawn delay by 25%
                timer = 0f;
            }

            // Wait for the specified delay before spawning the next object
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
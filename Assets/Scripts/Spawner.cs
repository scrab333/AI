using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //script used to generate enemies

    public List<GameObject> spawnableObjects;
    public float minSpawnIntervalInSeconds;
    public float maxSpawnIntervalInSeconds;

    private Player player;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        player = GetComponentInChildren<Player>();
        player.OnReset += DestroyAllSpawnedObjects;
        StartCoroutine(nameof(Spawn));
    }



    private void DestroyAllSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
            spawnedObjects.RemoveAt(i);
        }
    }

    //get object to spawn
    private GameObject GetRandomSpawnableFromList()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnableObjects.Count);
        return spawnableObjects[randomIndex];
    }


    private IEnumerator Spawn()
    {
        var spawned = Instantiate(GetRandomSpawnableFromList(), transform.position, transform.rotation, transform);
        spawnedObjects.Add(spawned);

        yield return new WaitForSeconds(Random.Range(minSpawnIntervalInSeconds, maxSpawnIntervalInSeconds));
        StartCoroutine(nameof(Spawn));
    }


}

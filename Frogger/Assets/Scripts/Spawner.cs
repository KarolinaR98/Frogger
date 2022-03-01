using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToSpawn;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float yPosition;
    [SerializeField] private float zPosition;
    [SerializeField] private List<GameObject> spawnPoints;
    Vector3 spawnerPosition;

    private void Awake()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)], spawnPoint.transform.position,
            spawnPoint.transform.rotation);
        }        
    }
    void Start()
    {
        spawnerPosition = transform.position;
        InvokeRepeating("Spawn", Random.Range(0, 1.5f), timeToSpawn);
    }

    private void Spawn()
     {
        Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)], new Vector3(spawnerPosition.x, yPosition, zPosition),
            transform.rotation);
        if (GameManager.endOfGame)
        {
            CancelInvoke();
        }
     }

   

    
}

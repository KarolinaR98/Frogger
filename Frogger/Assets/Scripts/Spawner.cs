using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToSpawn;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float yPosition;
    [SerializeField] private float zPosition;
    Vector3 spawnerPosition;
    void Start()
    {
        spawnerPosition = transform.position;
        InvokeRepeating("Spawn", 0f, timeToSpawn);
    }

    private void Spawn()
     {
        Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)], new Vector3(spawnerPosition.x, yPosition, zPosition),
            transform.rotation);
        if (!GameManager.playGame)
        {
            CancelInvoke();
        }
     }

   

    
}

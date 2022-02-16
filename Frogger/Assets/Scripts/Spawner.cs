using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float yPosition;
    Vector3 spawnerPosition;
    void Start()
    {
        spawnerPosition = transform.position;
        InvokeRepeating("Spawn", 0f, timeToSpawn);
    }


    private void Spawn()
    {
        Instantiate(prefabToSpawn, new Vector3(spawnerPosition.x, yPosition, 0) , transform.rotation);
    }

    
}

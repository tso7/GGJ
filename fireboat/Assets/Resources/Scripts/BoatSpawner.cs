using UnityEngine;
using System.Collections;

public class BoatSpawner : GenericSingleton<BoatSpawner>
{
    // Bird models
    public GameObject _boatPrefab;

    // Other variables
    public Vector3 spawnPosition;
    public float spawnWaitTime;
    public SoundManager soundManager;

    void Start()
    {
        StartCoroutine(SpawnBoats(_boatPrefab, 100));                     
    }
    
    // Spawn boats horizontally
    IEnumerator SpawnBoats(GameObject _boat, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_boat, spawnPosition, Quaternion.identity);
            //soundManager.playBoatSpawn();
            yield return new WaitForSeconds(spawnWaitTime);
        }
    }
 }


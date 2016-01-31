using UnityEngine;
using System.Collections;

public class BoatSpawner : GenericSingleton<BoatSpawner>
{
    // Bird models
    public GameObject _boatPrefab, _civilianPrefab;

    // Other variables
    public Vector3 spawnPosition;
    public float spawnWaitTime;
    public SoundManager soundManager;

    void Start()
    {
        StartCoroutine(SpawnBoats(200));                     
    }
    
    // Spawn boats horizontally
    IEnumerator SpawnBoats(int _count)
    {
        GameObject _boat;
        for (int i = 0; i < _count; i++)
        {
            if (i < 3)
                _boat = _boatPrefab;
            else if (i == 3)
                _boat = _civilianPrefab;
            else
            {
                float random = Random.Range(0, 4);
                _boat = random == 0 ? _civilianPrefab : _boatPrefab;
            }
            Instantiate(_boat, spawnPosition, Quaternion.identity);
            //soundManager.playBoatSpawn();
            yield return new WaitForSeconds(spawnWaitTime);
        }
    }
 }


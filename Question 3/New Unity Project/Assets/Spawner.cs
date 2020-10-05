using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnRate = 1;
    private float timeLeftBeforeSpawn = 0;
    public GameObject ennemie;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <= 0)
        {
            SpawEnnemie();
            timeLeftBeforeSpawn = spawnRate;
        }
    }

    private void SpawEnnemie()
    {
        Vector3 spawn = Vector3.zero;
        float randomSpawn = Random.Range(-10, 10);
        spawn.x = 25;
        spawn.y = randomSpawn;
        GameObject emptyGO = new GameObject();
        Transform SpawnPoint = emptyGO.transform;
        SpawnPoint.SetPositionAndRotation(spawn, Quaternion.identity);
        Instantiate(ennemie, SpawnPoint);
    }
}

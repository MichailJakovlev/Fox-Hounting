using System.Collections.Generic;
using UnityEngine;

public class SpawnRabbit : MonoBehaviour
{

    public GameObject[] rabbits;
    public List<Transform> spawnPoints;
    public List<Transform> spawnPointsSaves;
    public GameObject rabbitPrefab;


    public void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        spawnPointsSaves = new List<Transform>(spawnPointsSaves);
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnPointsSaves.Add(spawnPoints[i]);
        }

        for (int i = 0; i < rabbits.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(rabbits[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }

        spawnPoints.Clear();

        for(int i = 0;i < spawnPointsSaves.Count; i++)
        {
            spawnPoints.Add(spawnPointsSaves[i]);
        }
    }

    public void SpawnOnce()
    {
        var spawn = Random.Range(0, spawnPoints.Count);
        Instantiate(rabbitPrefab, spawnPoints[spawn].transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSpawner : MonoBehaviour
{
    public GameObject totem;
    public List<SpawnPoint> spawnPoints;

    public int totalTotems = 6;
	// Use this for initialization
	void Start ()
    {
        ChooseSpawnPoints();
	}

    void ChooseSpawnPoints()
    {
        for (int i = 0; i < totalTotems; i++)
        {
            Instantiate(totem, GetRandomSpawnPoint().position, Quaternion.identity);
        }
    }

    SpawnPoint GetRandomSpawnPoint()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Count);
        while (spawnPoints[randomSpawnPoint].isSelected)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Count);
        }

        spawnPoints[randomSpawnPoint].isSelected = true;
        return spawnPoints[randomSpawnPoint];
    }
}

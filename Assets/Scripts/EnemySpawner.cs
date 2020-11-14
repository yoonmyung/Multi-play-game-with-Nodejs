﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;
    public int numberOfEnemies;
    [HideInInspector]
    public List<SpawnPoint> enemeySpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f);
            SpawnPoint enemySpawnPoint = (Instantiate(
                spawnPoint, spawnPosition, spawnRotation) 
                as GameObject).GetComponent<SpawnPoint>();
            enemeySpawnPoints.Add(enemySpawnPoint);
        }
        SpawnEnemies();
    }
    public void SpawnEnemies(/* TO DO networking */)
    {
        //TO DO networking
        int i = 0;

        foreach (SpawnPoint sp in enemeySpawnPoints)
        {
            Vector3 position = sp.transform.position;
            Quaternion rotation = sp.transform.rotation;
            GameObject newEnemy = Instantiate(enemy, position, rotation) as GameObject;
            newEnemy.name = i + "";
            PlayerController pc = newEnemy.GetComponent<PlayerController>();
            pc.isLocalPlayer = false;
            Health h = newEnemy.GetComponent<Health>();
            h.currentHealth = 100;
            h.OnChangeHealth();
            h.destroyOnDeath = true;
            h.isEnemy = true;
            i++;
        }
    }
}

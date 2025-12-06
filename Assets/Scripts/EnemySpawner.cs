using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private BoxCollider2D[] SpawnZones;
    [SerializeField] private int countSpawnEnemy;


    private void Start()
    {
        SpawnEnemies();
    }


    private void SpawnEnemies()
    {
        for (int i = 0; i < countSpawnEnemy; i++)
        {
            Bounds bounds = SpawnZones[i].bounds;
            Vector3 spawnZone = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), 0f);
            GameObject enemy = Instantiate(Enemies[UnityEngine.Random.Range(0,Enemies.Length)], spawnZone, Quaternion.identity);
        }
    }



}

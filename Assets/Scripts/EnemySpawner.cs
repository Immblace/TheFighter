using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private BoxCollider2D[] SpawnZones;
    public bool spawnEnabled = true;


    private void Start()
    {
        if (spawnEnabled)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < SpawnZones.Length; i++)
        {
            Bounds bounds = SpawnZones[i].bounds;
            Vector3 spawnZone = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), 0f);
            GameObject enemy = Instantiate(Enemies[UnityEngine.Random.Range(0,Enemies.Length)], spawnZone, Quaternion.identity);
        }
    }

    public List<EnemyData> GetAllEnemiesData()
    {
        List<EnemyData> list = new List<EnemyData>();
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        foreach (Enemy enemy in enemies)
        {
            list.Add(enemy.GetEnemyData());
        }

        return list;
    }

    public void SpawnEnemiesFromSave(List<EnemyData> enemies)
    {
        foreach (var e in enemies)
        {
            GameObject newEnemy = Instantiate(Enemies[e.enemyType]);
            newEnemy.GetComponentInChildren<Enemy>().ApplyEnemyData(e);
        }
    }

    public void ClearAllEnemies()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        spawnEnabled = false;

        foreach (var item in enemies)
        {
            Destroy(item.transform.parent.gameObject);
        }
    }
}

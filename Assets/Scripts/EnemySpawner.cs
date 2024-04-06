using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Enemy enemyScript;
    public GameObject enemyPrefab;

    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        enemyPrefab = enemyScript.enemyObject;
    }

    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-16f, 16f);
        float randomY = Random.Range(-8f, 8f);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}

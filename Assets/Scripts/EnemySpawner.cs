using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float CurrentTime;
    

    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime > 0.5f) {
            SpawnEnemy();
            CurrentTime = 0;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-31.5f, 31.5f);
        float randomY = Random.Range(-15f, 15f);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}

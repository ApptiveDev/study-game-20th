using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject StrongEnemyPrefab;
    float CurrentTime1;
    float CurrentTime2;
    

    void Update()
    {
        CurrentTime1 += Time.deltaTime;
        CurrentTime2 += Time.deltaTime;

        if (CurrentTime1 > 0.5f) {
            SpawnEnemy();
            CurrentTime1 = 0;
        }

        if (CurrentTime2 > 3f) {
            SpawnStrongEnemy();
            CurrentTime2 = 0;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-31.5f, 31.5f);
        float randomY = Random.Range(-15f, 15f);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }

    void SpawnStrongEnemy()
    {
        float randomX = Random.Range(-31.5f, 31.5f);
        float randomY = Random.Range(-15f, 15f);

        GameObject StrongEnemy = Instantiate(StrongEnemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}

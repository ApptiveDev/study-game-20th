using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Character CH;
    public GameObject enemyPrefab;
    public GameObject StrongEnemyPrefab;
    public GameObject BossPrefab;
    float CurrentTime1;
    float CurrentTime2;
    bool flag = true;
    

    void Update()
    {
        CH = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (!CH.GameOver)
        {
            if (flag)
            {
                CurrentTime1 += Time.deltaTime;
                CurrentTime2 += Time.deltaTime;
            }
            
            if (CurrentTime1 > 0.5f) {
                SpawnEnemy();
                CurrentTime1 = 0;
            }

            if (CurrentTime2 > 4f) {
                SpawnStrongEnemy();
                CurrentTime2 = 0;
            }

            
            if (CH.Level == 2 && flag)
            {
                BossSpawn();
                flag = false;
            }
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

    void BossSpawn()
    {
        Instantiate(BossPrefab,new Vector2(38.5f,0),Quaternion.identity);
    }
}

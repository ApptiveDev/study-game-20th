using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolAble
{
    public string enemyObjectName;
    private ObjectPoolManager poolManager;
    // Start is called before the first frame update
    void Start()
    {
        poolManager = ObjectPoolManager.instance;  // 오브젝트풀매니저 가져오기
        currTime = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime; //시간 흐르게하기

        if(currTime > 5f) //5초마다 생성
        {
           SpawnEnemy();
           currTime = 0f; //시간 초기화
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = poolManager.GetGo(enemyObjectName);

        if (enemy != null)
        {
            float randomX = Random.Range(-20f, 20f);  
            float randomY = Random.Range(-20f, 20f); 

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            enemy.transform.position = spawnPosition;

            // 적 캐릭터 활성화
            enemy.SetActive(true);
    }
}

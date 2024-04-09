using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 2;

    [SerializeField] GameObject enemyObject;

    //몇초에 한번씩 랜덤한 위치에 스폰시키고 싶다

    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }


    float currentDelay = 0f;
    void Update()
    {
        //if (currentDelay < spawnDelay)
        //{
        //    currentDelay += Time.deltaTime;
        //}
        //else
        //{
        //    for(int i = 0; i < spawnAmount; i++)
        //    {
        //        currentDelay = 0f;
        //        SpawnObject();
        //    }
        //}
    }

    IEnumerator SpawnbyTime() // 코루틴
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        //스폰
        Instantiate(enemyObject, GetRndPos(), Quaternion.identity);
    }
    
    Vector3 GetRndPos()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        Vector3 rndPos = new Vector3(x, y, 0);
        return rndPos;
    }
}

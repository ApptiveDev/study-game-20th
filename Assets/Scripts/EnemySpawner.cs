using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    float currTime = 0f; //시간 담당 변수
    void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (currTime < 3f)
        {
            currTime += Time.deltaTime; //시간 흐르게하기
        }
        
        else
        {
           for (int i = 0; i < 2; i++)
           {
            SpawnOject();
           }
           currTime = 0f; //시간 초기화
        }
        */
    }

    IEnumerator SpawnbyTime()
    {   
        while(true)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 2; i++)
            {
                SpawnOject();
            }
        }
    }

    void SpawnOject()
    {
        Instantiate(enemyPrefab, GetRndPos(), Quaternion.identity);
        //에너미 호출
    }
    Vector3 GetRndPos()
    {
        float newX = Random.Range(-10f,10f), newY = Random.Range(-10f,10f);
        //X, Y좌표 10 10안에서 랜덤 생성
        //근데 왜 내 배경 스케일은 100 100인데 위치 범위는 다르지?
        Vector3 spawnPosition = new Vector3(newX, newY, 0f); 
        // 생성 위치 설정
        return spawnPosition;
    }
}

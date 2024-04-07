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
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime; //시간 흐르게하기

        if(currTime > 5f) //10초마다 생성
        {
           float newX = Random.Range(-10f,10f), newY = Random.Range(-10f,10f);
           //X, Y좌표 10 10안에서 랜덤 생성
            
           Vector3 spawnPosition = new Vector3(newX, newY, 0f); 
           // 생성 위치 설정

           Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
           //에너미 호출

           currTime = 0f; //시간 초기화
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrEnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnStrDelay = 1f;
    [SerializeField] int spawnStrAmount = 1;
    [SerializeField] GameObject StrenemyObject;

    public List<Enemy> StrenemyList;
    GameObject spawnedStrenemyObj;
    Enemy spawnedStrenemy;
    Enemy enemy;
    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();//이렇게 가져오는거 맞나
        if(enemy.DeadCount == 30)
        {
            StartCoroutine(SpawnStrbyTime());
            enemy.DeadCount = 0;
        }
    }

    IEnumerator SpawnStrbyTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnStrDelay);   
            for (int i = 0; i < spawnStrAmount; i++)
            {
                spawnedStrenemyObj = SpawnStrObject();
                spawnedStrenemy = spawnedStrenemyObj.GetComponent<Enemy>();
                StrenemyList.Add(spawnedStrenemy);
            }
        }
    }

    GameObject  SpawnStrObject()
    {
        return Instantiate(StrenemyObject, GetStrRndPos(), Quaternion.identity);
    }

    Vector3 GetStrRndPos()
    {
        float StrrandomX = Random.Range(-20f, 20f);  
        float StrrandomY = Random.Range(-20f, 20f); 

        return new Vector3(StrrandomX, StrrandomY, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 2;
    [SerializeField] GameObject enemyObject;

    public List<Enemy> enemyList;
    GameObject spawnedenemyObj;
    Enemy spawnedenemy;
    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    IEnumerator SpawnbyTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);   
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedenemyObj = SpawnObject();
                spawnedenemy = spawnedenemyObj.GetComponent<Enemy>();
                enemyList.Add(spawnedenemy);
            }
        }
    }

    GameObject  SpawnObject()
    {
        return Instantiate(enemyObject, GetRndPos(), Quaternion.identity);
    }

    Vector3 GetRndPos()
    {
        float randomX = Random.Range(-20f, 20f);  
        float randomY = Random.Range(-20f, 20f); 

        return new Vector3(randomX, randomY, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

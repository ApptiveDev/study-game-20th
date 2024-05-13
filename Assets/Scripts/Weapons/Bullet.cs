using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    Transform target ;
    Vector3 moveVector;
    EnemySpawner spawner;

    Transform FindShorttestTtarget()
    {
        float shortest = float.MaxValue;
        int shortestIndex  = -1;
        spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        List<Enemy> enemyList =  spawner.enemyList;
        for(int i = 0; i < enemyList.Count; i++)
        {
            float distance  = Vector3.Distance(enemyList[i].transform.position, transform.position);
            if(distance < shortest)
            {
                shortest = distance;
                shortestIndex = i;
            }
        }
        if (shortestIndex == -1) 
        {
            return null;
        }
        return enemyList[shortestIndex].transform;
    }
    void Start()
    {   
        target = FindShorttestTtarget();
        if(target == null)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        moveVector = target.transform.position - transform.position;
        transform.position += moveVector.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.Equals(target))
        {
            Destroy(target);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    Transform target;
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damage = 10f;

    EnemySpawner spawner;


    const float THRESHOLD_REACHED = 0.001f;

    //가장 가까운 적을 찾는다

    Transform FindShortestTarget()
    {
        float shortest = float.MaxValue;
        int shortestIndex = -1;
        spawner = GameObject.FindObjectOfType<EnemySpawner>();
        List<Enemy> enemyList = spawner.enemyList;

        for (int i = 0; i < enemyList.Count; i++)
        {
            float distance = Vector3.Distance(enemyList[i].transform.position, transform.position);
            if (distance < shortest)
            {
                shortest = distance;
                shortestIndex = i;
            }
        }

        if (shortestIndex == -1)
        {
            Debug.Log(name + " Not Found Target!");
            return null; 
        }

        return enemyList[shortestIndex].transform;
    }

    void Start()
    {
        target = FindShortestTarget();
        if(target == null)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //적을 향해 날아간다
        moveVector = target.transform.position - transform.position;
        if (moveVector.magnitude < THRESHOLD_REACHED) gameObject.SetActive(false);

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //그리고 도달 시 데미지를 주고 수리검은 소멸된다.
        if (collision.transform.Equals(target))
        {
            target.GetComponent<Enemy>().ExecuteOnDamaged(damage);
            Destroy(gameObject);
        }
    }
}

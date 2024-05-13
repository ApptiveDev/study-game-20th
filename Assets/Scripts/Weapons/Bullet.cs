using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    Transform target ;
    Vector3 moveVector;

    Transform FindShorttestTtarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearestEnemy = null;
        float shortestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
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
        if (collision.CompareTag("Enemy") && collision.transform == target)
        {
            Destroy(gameObject);
        }
    }
}
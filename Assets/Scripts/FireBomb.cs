using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : MonoBehaviour
{
    GameObject target;
    Vector3 initialTargetDirection;
    bool isTargetSet = false;

    void Start() 
    {
        ClosestEnemy();
    }

    void Update()
    {
        if (isTargetSet)
        {
            AttackEnemy();
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Vector2.Distance(transform.position, player.transform.position) > 30f)
        {
            Destroy(gameObject);
        }
    }

    void ClosestEnemy() 
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies)
        {
            float enemyDistance = Vector2.Distance(enemy.transform.position, transform.position);
            if (distance > enemyDistance)
            {
                distance = enemyDistance;
                target = enemy;
            }
        }

        if (target != null)
        {
            initialTargetDirection = (target.transform.position - transform.position).normalized;
            isTargetSet = true;
            Vector3 targetDirection = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void AttackEnemy()
    {
        transform.position += initialTargetDirection * 4f * Time.deltaTime;
    }
}


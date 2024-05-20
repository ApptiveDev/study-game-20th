using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    float flag = 0;
    private float EnemyHealthPoint = 2f;
    public GameObject ExpCoin;
    
    void Update() 
    {
        EnemyMoveToPlayer();
    }

    void EnemyMoveToPlayer() 
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null) {
            player = playerObject.transform;

            float distanceVector = Vector3.Distance(transform.position, player.position);

            if (distanceVector < 33f) {
                flag = 1;
            }

            if (flag == 1) {
                transform.position = Vector3.MoveTowards(transform.position, player.position, 1.5f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
        {
            EnemyHealthPoint--;
            if (EnemyHealthPoint < 1) 
            {
                LeaveExp();
                EnemyDead();
            }
        }
    }

    private void EnemyDead()
    {
        Character.Point++;
        Destroy(gameObject);
    }

    private void LeaveExp() {
        Instantiate(ExpCoin,transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    GameObject ExpObject;
    float moveSpeed = 2f;
    Vector3 moveVector;
    public GameObject ExpObjectPrefab;

    void Start()
    {
        
    }
    
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveVector = player.transform.position - transform.position;
        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Weapon")) 
        {
                EnemyDead() ;
                LeaveExp() ;
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }

    void LeaveExp() 
    {
        ExpObject = Instantiate(ExpObjectPrefab ,transform.position, Quaternion.identity);
    }
}

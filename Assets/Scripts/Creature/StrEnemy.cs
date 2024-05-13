using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrEnemy : MonoBehaviour
{
    GameObject player;
    GameObject ExpObject;
    float moveStrSpeed = 1f;
    Vector3 moveStrVector;
    public GameObject ExpObjectPrefab;
    public int Health = 100;

    void Start()
    {
        
    }
    
    void Update()
    {
        EnemyMove();
        if(Health<1)
        {
            EnemyDead() ;
            LeaveExp() ;
        }
    }

    void EnemyMove()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveStrVector = player.transform.position - transform.position;
        transform.position += moveStrVector.normalized * moveStrSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Weapon")) 
        {
                StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        while (true)
        {
            Health -= 10;
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }

    void LeaveExp() 
    {
        for (int i = 0; i<2; i++)
        {
            ExpObject = Instantiate(ExpObjectPrefab ,transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 moveVector;

    GameObject player;
    Character character;
    float moveSpeed = 3f;
    EnemySpawner spawner;

    bool isInit = false;

    [SerializeField] float healthPoint = 10f;
    [SerializeField] float damage = 10f;

    public void ExecuteOnDamaged(float damage)
    {
        healthPoint -= damage;
        if(healthPoint <= 0)
        {
            ExecuteOnDead();
        }
    }

    public void ExecuteOnDead()
    {
        gameObject.SetActive(false);
        spawner.enemyList.Remove(this);
    }

    public void ExecuteOnInit(EnemySpawner spawner)
    {
        this.spawner = spawner;
        player = GameObject.Find("Character");
        moveSpeed = Random.Range(1f, 3f);
        character = player.GetComponent<Character>();
        isInit = true;
    }

    void Update()
    {
        if (isInit)
        {
            moveVector = player.transform.position - transform.position;
            transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name.Equals("Character"))
        {
            character.ExecuteOnDamaged(damage);
            ExecuteOnDead();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : MonoBehaviour
{
    private float EnemyHealthPoint = 2f;
    public GameObject ExpCoin;
    GameObject player;
    [SerializeField] private GameObject StrongEnemyBall;
    float CurrentTime;


    void Update()
    {
        ShootBall();
    }

    void ShootBall()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime > 3f)
        {
            Instantiate(StrongEnemyBall,transform.position,Quaternion.identity);
            CurrentTime = 0;
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
        Destroy(gameObject);
    }

    private void LeaveExp() {
        Instantiate(ExpCoin,transform.position, Quaternion.identity);
    }
}

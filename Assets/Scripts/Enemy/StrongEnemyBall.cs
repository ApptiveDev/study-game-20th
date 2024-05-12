using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyBall : MonoBehaviour
{
    GameObject player;
    Vector3 TargetDirection;
    float CurrentTime = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        TargetDirection = (player.transform.position - transform.position).normalized;
    }

    void Update()
    {
        CurrentTime += Time.deltaTime;
        transform.position += TargetDirection * 4f * Time.deltaTime;
        if (CurrentTime > 8)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    
    void Update() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceVector = Vector3.Distance(transform.position, player.position);

        transform.position = Vector3.MoveTowards(transform.position, player.position, 1.5f * Time.deltaTime);
    }
}

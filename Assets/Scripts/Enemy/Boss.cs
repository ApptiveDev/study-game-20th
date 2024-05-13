using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float BossHealthPoint = 20f;
    GameObject player;
    void Update()
    {
        MoveToCharacter();
    }

    void MoveToCharacter()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1.5f*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
        {
            BossHealthPoint--;
            if (BossHealthPoint < 1) 
            {
                Destroy(gameObject);
                Time.timeScale = 0f;
            }
        }
    }
}

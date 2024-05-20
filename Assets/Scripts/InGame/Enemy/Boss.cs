using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Character CH;
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
        CH = GameObject.Find("Character").GetComponent<Character>();
        if (other.tag == "Weapon")
        {
            BossHealthPoint--;
            if (BossHealthPoint < 1) 
            {
                CH.GameOver = true;
                CH.GameClear = true;
                Character.Point += 10;
                Destroy(gameObject);
                Time.timeScale = 0.33f;
            }
        }
    }
}

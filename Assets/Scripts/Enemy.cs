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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        moveSpeed = Random.Range(1f,3f);
        character = player.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.transform.position - transform.position;
        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name.Equals("Character"))
        {
            character.ExecuteOnDamaged();
        }
    }
}

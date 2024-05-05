using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{    
    private float CharacterHealthPoint = 10f;
    public static int Exp = 0;
    public static int Level = 0;
    void Update()
    {
        MoveAndflip();   
    }

    void MoveAndflip() 
    {
        Vector2 vec = new Vector2(0f,0f);

        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.localScale = new Vector3(3.3849f,3.3849f,3.3849f);
            vec.x = -1f;
        }

        if (Input.GetKey (KeyCode.RightArrow)) {
            transform.localScale = new Vector3(-3.3849f,3.3849f,3.3849f);
            vec.x = 1f;
        }

        if (Input.GetKey (KeyCode.UpArrow)) {
            vec.y = 1f;
        }

        if (Input.GetKey (KeyCode.DownArrow)) {
            vec.y = -1f;
        }

        transform.Translate(vec.normalized * Time.deltaTime * 8f);

        if (transform.position.x < -16) {
            transform.position = new Vector3(-16,transform.position.y,0);
        }

        if (transform.position.x > 16) {
            transform.position = new Vector3(16,transform.position.y,0);
        }

        if (transform.position.y < -9.6) {
            transform.position = new Vector3(transform.position.x,-9.6f,0);
        }

        if (transform.position.y > 5.25f) {
            transform.position = new Vector3(transform.position.x,5.25f,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            CharacterHealthPoint--;
            CharaterDead();
        }
    }

    private void CharaterDead()
    {
        if (CharacterHealthPoint < 1)
            {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            }
    }
}

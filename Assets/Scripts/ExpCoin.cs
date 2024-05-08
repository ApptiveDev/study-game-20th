using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Character.Exp++;
            FindObjectOfType<Character>().LevelUp();
            Destroy(gameObject);
        }
    }
}

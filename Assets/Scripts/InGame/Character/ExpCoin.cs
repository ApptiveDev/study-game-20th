using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCoin : MonoBehaviour
{
    Character CH;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CH = GetComponent<Character>();
        if (other.tag == "Player")
        {
            // static변수를 받는거보단 GameObject를 가져와서 불러오는게 충돌적음
            CH = GameObject.Find("Character").GetComponent<Character>(); 
            CH.Exp++;
            FindObjectOfType<Character>().CheckLevelUp();
            Destroy(gameObject);
        }
    }
}

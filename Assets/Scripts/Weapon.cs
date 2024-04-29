using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    protected int numAttack = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Weapon Attack");
        if (collision.tag == "Enemy")
        {
            numAttack += 1;
            collision.GetComponent<SlimeController>().Damaged();
        }
    }

}

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
            if (Character.Exp > (Character.Level+1) * 5 && Character.Level < 3)
            {
                Character.Level++;
                FindObjectOfType<WeaponSpawner>().SpawnWeapon();
                Character.Exp = 0;
            }
            Destroy(gameObject);
        }
    }
}

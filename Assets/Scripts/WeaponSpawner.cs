using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;

    void Start() 
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        GameObject weapon = Instantiate(weaponPrefab, new Vector3(1.5f,0,0), Quaternion.identity);
    }
}

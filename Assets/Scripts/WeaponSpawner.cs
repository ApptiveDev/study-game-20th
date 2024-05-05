using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    public static GameObject[] weapons = new GameObject[3];
    public ExpCoin ExpCoinScript;
    int Level;

    void Start() 
    {
        SpawnWeapon();
    }

    public void SpawnWeapon()
    {
        Level = Character.Level;
        GameObject weapon = Instantiate(weaponPrefab, new Vector3(1.5f,0,0), Quaternion.identity);
        weapons[Level] = weapon;
    }
}

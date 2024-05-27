using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject[] weapons = new GameObject[5];
    public RotatingWeapon RW;
    private int Level;

    void Start() 
    {
        SpawnWeapon();
    }

    public void SpawnWeapon()
    {
        RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
        Level = RW.Level;
        GameObject weapon = Instantiate(weaponPrefab, new Vector3(1.5f,0,0), Quaternion.identity);
        weapons[Level] = weapon;
    }
}

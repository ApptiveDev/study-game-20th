using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSpawner : MonoBehaviour
{
    public GameObject axePrefab;
    public GameObject bulletSpawnerPrefab;
    public GameObject sanctuaryPrefab;
    public string WeaponObjectName;

    private GameObject[] weapons = new GameObject[3]; // 무기 배열

    void Start()
    {
        SpawnWeapons();
    }

    public void SpawnWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        
        GameObject axe = Instantiate(axePrefab, playerPosition, Quaternion.identity);
        weapons[0] = axe;

        GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, playerPosition, Quaternion.identity);
        weapons[1] = bulletSpawner;

        GameObject sanctuary = Instantiate(sanctuaryPrefab, playerPosition, Quaternion.identity);
        weapons[2] = sanctuary;
    }
}
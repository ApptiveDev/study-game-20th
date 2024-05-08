using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSpawner : PoolAble
{
    public GameObject axePrefab;
    public GameObject bulletPrefab;
    public GameObject sanctuaryPrefab;
    private ObjectPoolManager poolManager;
    public string WeaponObjectName;

    private GameObject[] weapons = new GameObject[3]; // 무기 배열

    void Start()
    {
        poolManager = ObjectPoolManager.instance;
        SpawnWeapons();
    }

    public void SpawnWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = player.transform.position;
        
        GameObject axe = poolManager.GetGo("Axe");
        axe.transform.position = playerPosition;
        axe.SetActive(true);
        weapons[0] = axe;

        GameObject bullet = poolManager.GetGo("Bullet");
        bullet.transform.position = playerPosition;
        bullet.SetActive(true);
        weapons[1] = bullet;

        GameObject sanctuary = poolManager.GetGo("Sanctuary");
        sanctuary.transform.position = playerPosition;
        sanctuary.SetActive(true);
        weapons[2] = sanctuary;
    }
}
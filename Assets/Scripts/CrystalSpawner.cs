using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : WeaponSpawner
{
    [SerializeField] float spawnRange = 5f;


    Vector3 GetRandomSpawnPosition()
    {
        return transform.position + new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange, spawnRange));
    }

    protected override GameObject SpawnObject()
    {
        //½ºÆù
        return Instantiate(weaponObject, GetRandomSpawnPosition(), Quaternion.identity);
    }
   
}

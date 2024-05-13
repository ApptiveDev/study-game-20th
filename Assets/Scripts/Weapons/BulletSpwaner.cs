using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwaner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] int WeaponLevel = 1;
    [SerializeField] GameObject bulletObject;
    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    IEnumerator SpawnbyTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);   
            for (int i = 0; i < spawnAmount*WeaponLevel; i++)
            {
                SpawnObject();
            }
        }
    }

    GameObject  SpawnObject()
    {
        return Instantiate(bulletObject, GetSpawnPos(), Quaternion.identity);
    }

    Vector3 GetSpawnPos()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 spawnPosition = player.transform.position ;

        return spawnPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

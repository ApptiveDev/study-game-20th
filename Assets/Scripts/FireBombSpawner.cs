using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombSpawner : MonoBehaviour
{
    public GameObject FireBombPrefab;
    float CurrentTime;
    public static float SpawnTime = 3f;
    GameObject player;
    

    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime > SpawnTime) {
            SpawnFireBomb();
            CurrentTime = 0;
        }
    }

    void SpawnFireBomb()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject FireBomb = Instantiate(FireBombPrefab, player.transform.position, Quaternion.identity);
    }
}

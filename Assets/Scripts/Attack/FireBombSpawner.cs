using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombSpawner : MonoBehaviour
{
    Character CH;
    public GameObject FireBombPrefab;
    float CurrentTime;
    public static float SpawnTime = 2f;
    GameObject player;
    

    void Update()
    {
        CH = GameObject.Find("Character").GetComponent<Character>();
        CurrentTime += Time.deltaTime;

        if (CurrentTime > SpawnTime && !CH.GameOver) {
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

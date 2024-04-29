using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 1;

    [SerializeField] GameObject hammerObject;

    [SerializeField] Hammer hammer;

    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }

    IEnumerator SpawnbyTime() // 코루틴
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnObject();
                hammer.Init();
            }
        }
    }

    void SpawnObject()
    {
        //스폰
        hammer = Instantiate(hammerObject, transform.position, Quaternion.identity).GetComponent<Hammer>();
    }
}

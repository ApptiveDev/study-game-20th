using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 1;

    [SerializeField] GameObject knifeObject;

    Knife knife;

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
                SetKnifeTarget();
            }
        }
    }

    void SpawnObject()
    {
        //스폰
        knife = Instantiate(knifeObject, transform.position, Quaternion.identity).GetComponent<Knife>();
    }

    void SetKnifeTarget()
    {
        if(EnemySpawner.instance.enemyList.Count > 0)
        {
            Enemy target = EnemySpawner.instance.enemyList[0];
            knife.Init(target.gameObject);
        }
        else
        {
            knife.gameObject.SetActive(false);
            knife = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackEnemyPoolController : ObjectPoolController
{
    [SerializeField] GameObject LongAttackEnemy;
    GameManager gameManager;
    Transform playerTransform;

    bool spawnObject = true;

    public void SetSpawnObject(bool boolValue)
    {
        spawnObject = boolValue;
    }

    public void isDead(GameObject enemy)
    {
        AddToPool(enemy);
    }

    private void AddtoEnemyList()
    {
        for (int i = 0; i < ObjectPool.Count; i++)
        {
            gameManager.addEnemy(ObjectPool[i]);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        playerTransform = gameManager.getPlayer().transform;
        MakeObjects(LongAttackEnemy, 10);
        AddtoEnemyList();
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            if (spawnObject)
            {
                RandomSpawnObject(playerTransform.position);
            }
        }
    }
}

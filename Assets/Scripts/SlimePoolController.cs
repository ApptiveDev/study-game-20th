using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePoolController : ObjectPoolController
{

    [SerializeField] GameObject slime;
    GameManager gameManager;
    bool spawnObject = true;

    public void SetSpawnObject(bool boolValue)
    {
        spawnObject = boolValue;
    }

    public void isDead(GameObject deadSlime)
    {
        AddToPool(deadSlime);
    }

    private void AddtoEnemyList()
    {
        for (int i =0; i < ObjectPool.Count; i++)
        {
            gameManager.addEnemy(ObjectPool[i]);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        MakeObjects(slime, 10);
        AddtoEnemyList();
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            if (spawnObject)
            {
                RandomSpawnObject();
            } 
        }
    }

}

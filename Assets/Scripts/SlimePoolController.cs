using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePoolController : ObjectPoolController
{

    public GameObject slime;
    List<GameObject> SlimePool = new List<GameObject>();
    GameManager gameManager;

    public void isDead(GameObject deadSlime)
    {
        SlimePool.Add(deadSlime);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getInstance();
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(slime, new Vector3(0, 0, 0), Quaternion.identity);
            SlimePool.Add(temp);
            gameManager.addEnemy(temp);
            SlimePool[i].SetActive(false);
        }
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            RandomSpawnObject(SlimePool);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlopPoolController : ObjectPoolController
{

    public GameObject Glop;
    List<GameObject> GlopPool = new List<GameObject>();
    Transform playerTransform;

    public void isDead(GameObject deadGlop)
    {
        GlopPool.Add(deadGlop);
    }



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(Glop, new Vector3(10, 10, 0), Quaternion.identity);
            GlopPool.Add(temp);
            GlopPool[i].SetActive(false);
        }
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            print("fuck that");
            yield return new WaitForSeconds(1);
            SpawnObject(playerTransform.position, GlopPool);
        }
    }
}

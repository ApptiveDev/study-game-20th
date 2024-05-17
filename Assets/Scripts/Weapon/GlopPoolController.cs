using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlopPoolController : ObjectPoolController
{

    [SerializeField] GameObject Glop;
    Transform playerTransform;
    int shotGlopTime = 4;

    public int getShotGlopTime()
    {
        return shotGlopTime;
    }

    public void setShotGlopTime(int time)
    {
        shotGlopTime = time;
    }

    public void isDead(GameObject deadGlop)
    {
        AddToPool(deadGlop);
    }



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        MakeObjects(Glop, 10);
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        { 
            yield return new WaitForSeconds(shotGlopTime);
            SpawnObject(playerTransform.position);
        }
    }
}

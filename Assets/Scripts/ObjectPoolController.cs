using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class ObjectPoolController : MonoBehaviour
{


    protected void RandomSpawnObject(List<GameObject> pool)
    {
        if (pool.Count > 0)
        {
            print("RandomSpawned");
            float y = Random.RandomRange(-5, 5);
            float x = Random.RandomRange(-7, 7);
            GameObject bady = pool[0];
            bady.SetActive(true);
            pool.RemoveAt(0);
            
            bady.GetComponent<Transform>().position = new Vector3(x, y, 0);

        } else
        {
            return;
        }
    }

    protected void SpawnObject(Vector3 position, List<GameObject> pool)
    {
        if (pool.Count > 0)
        {
            print("Spawned");
            GameObject bady = pool[0];
            if (bady == null)
            {
                print("qudtlsrkxdms roRldi dho dlrp sjfdlsi tlqkf wlsWk whwrkxsp");
            }
            bady.SetActive(true);
            pool.RemoveAt(0);

            bady.GetComponent<Transform>().position = new Vector3(position.x, position.y, 0);

        }
        else
        {
            print("fuck");
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

}

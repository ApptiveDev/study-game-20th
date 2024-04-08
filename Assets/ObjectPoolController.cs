using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class ObjectPoolController : MonoBehaviour
{
    public GameObject slime;
    List<GameObject> SlimePool = new List<GameObject>();
    IEnumerator  SpawnSlime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            RandomSpawnSlime();
        }
    }

    public void isDead(GameObject deadSlime)
    {
        SlimePool.Add(deadSlime);
    }

    void RandomSpawnSlime()
    {
        if (SlimePool.Count > 0)
        {
            print("Spawned");
            float y = Random.RandomRange(-5, 5);
            float x = Random.RandomRange(-7, 7);
            GameObject slimeBady = SlimePool[0];
            slimeBady.SetActive(true);
            SlimePool.RemoveAt(0);
            
            slimeBady.GetComponent<Transform>().position = new Vector3(x, y, 0);

        } else
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; i++)
        {
            GameObject temp = Instantiate(slime, new Vector3(0, 0, 0), Quaternion.identity);
            SlimePool.Add(temp);
            SlimePool[i].SetActive(false);
        }
        StartCoroutine(SpawnSlime());
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

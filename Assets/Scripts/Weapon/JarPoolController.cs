using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarPoolController : ObjectPoolController
{

    [SerializeField] GameObject Jar;

    GameManager gameManager;

    int shotJarTime = 2;

    public int getShotJarTime()
    {
        return shotJarTime;
    }

    public void setShotJarTime(int time)
    {
        shotJarTime = time;
    }

    public void isDead(GameObject jar)
    {
        AddToPool(jar);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        MakeObjects(Jar, 10);
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotJarTime);
            GameObject body = SpawnObject(transform.position);
            if (body != null)
            {
                body.GetComponent<JarController>().InitJar();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolController : ObjectPoolController
{
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        MakeObjects(coin, 100);
    }

    public void ReturnExpJam(GameObject Object)
    {
        AddToPool(Object);
    }

    public void DropExpJam(Vector3 position)
    {
        SpawnObject(position);
    }
}

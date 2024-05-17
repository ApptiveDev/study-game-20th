using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackEnemyWeaponPoolController : ObjectPoolController
{

    [SerializeField] GameObject Arrow;

    GameManager gameManager;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        playerTransform = gameManager.getPlayer().transform;
        MakeObjects(Arrow, 100);
    }

    public void ShotArrowToPlayer(Vector3 startPosition)
    {

        GameObject body = SpawnObject(startPosition);
        if (body != null)
        {
            body.GetComponent<LongAttackEnemyWeaponController>().InitArrow(playerTransform.position);
        }

    }
}

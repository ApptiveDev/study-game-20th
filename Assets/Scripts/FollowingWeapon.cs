using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingWeapon : Weapon
{
    GameManager gameManager;
    private GlopPoolController mGlopPoolController;
    Transform playerTransform;
    public GameObject targetObject;

    GameObject FindCloseEnemy()
    {
        List<GameObject> enemyList = gameManager.getEnemyList();
        int num = enemyList.Count;
        int MostCloseIndex = -1;
        float MostCloseDistence = float.MaxValue;
        for (int i = 0; i < num; i++)
        {
            if (enemyList[i].active)
            {
                Vector3 enemyPosition = enemyList[i].GetComponent<Transform>().position;
                float distence = Mathf.Pow(enemyPosition.x - playerTransform.position.x, 2) + Mathf.Pow(enemyPosition.y - playerTransform.position.y, 2);
                if (MostCloseDistence > distence)
                {
                    MostCloseDistence = distence;
                    MostCloseIndex = i;
                }
            }
        }

        if (MostCloseIndex != -1)
        {
            print("is not null");
            return enemyList[MostCloseIndex];
        }
        else
        {
            print("tlqkftlqkftlqkf");
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getInstance();
        mGlopPoolController = gameManager.getPlayer().GetComponent<GlopPoolController>();
        playerTransform = gameObject.GetComponent<Transform>();
        targetObject = FindCloseEnemy();
        if (targetObject == null)
        {
            print("isNull");
            mGlopPoolController.isDead(gameObject);
            
        }
    }

    private void Move()
    {
        //print("tlqkf");
        float deltaX = targetObject.transform.position.x - transform.position.x;
        float deltaY = targetObject.transform.position.y - transform.position.y;
        float a = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        transform.position += new Vector3(Time.deltaTime * deltaX / a , Time.deltaTime * deltaY / a );
    }

    // Update is called once per frame
    void Update()
    {
        if (numAttack >= 1)
        {
           
            mGlopPoolController.isDead(gameObject);
            gameObject.SetActive(false);
        }

        if (targetObject == null | !targetObject.active)
        {
            targetObject = FindCloseEnemy();
            if (targetObject == null)
            {
                print("isNull");
                mGlopPoolController.isDead(gameObject);

            }
        }

        Move();

    }
}

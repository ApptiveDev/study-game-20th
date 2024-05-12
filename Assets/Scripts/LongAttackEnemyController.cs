using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackEnemyController : Enemy
{
    Transform playerTransform;
    Rigidbody2D mRigid;
    LongAttackEnemyWeaponPoolController mArrowPoolController;
    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        objectPoolController = GameManager.Instance.getGameManager().GetComponent<LongAttackEnemyPoolController>();//GameObject.Find("GameManager").GetComponent<SlimePoolController>();
        playerTransform = GameManager.Instance.getPlayer().GetComponent<Transform>();//GameObject.Find("BOD").GetComponent<Transform>();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
        mExpJamPoolController = GameManager.Instance.getExpJamPoolController();
        mArrowPoolController = GameManager.Instance.getGameManager().GetComponent<LongAttackEnemyWeaponPoolController>();
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            mArrowPoolController.ShotArrowToPlayer(transform.position);
        }
    }
    void InitAttack()
    {
        isAttacking = true;
        StartCoroutine(Attack());
    }

    private void Move()
    {
        float deltaX = playerTransform.position.x - transform.position.x;
        float deltaY = playerTransform.position.y - transform.position.y;
        if (deltaX <= 5 | deltaY <= 5)
        {
            if (!isAttacking)
            {
                InitAttack();
            }
            return;
        }
        else
        {
            float a = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
            mRigid.velocity = new Vector2(deltaX / a, deltaY / a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

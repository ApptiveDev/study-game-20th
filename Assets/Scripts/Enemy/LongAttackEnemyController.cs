using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackEnemyController : Enemy
{
    LongAttackEnemyWeaponPoolController mArrowPoolController;
    bool isAttacking = false;

    void Start()
    {
        base.Start();
        objectPoolController = gameManager.getGameManagement().GetComponent<LongAttackEnemyPoolController>();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
        mExpJamPoolController = gameManager.getExpJamPoolController();
        mCoinPoolController = gameManager.getGameManagement().GetComponent<CoinPoolController>();
        mArrowPoolController = gameManager.getGameManagement().GetComponent<LongAttackEnemyWeaponPoolController>();
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
        if (Mathf.Abs(deltaX) <= 10 && Mathf.Abs(deltaY) <= 10)
        {
            mRigid.velocity = Vector2.zero;
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

    void Update()
    {
        Move();
    }
}

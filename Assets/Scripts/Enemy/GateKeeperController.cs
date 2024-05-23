using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeeperController : Enemy
{
    Animator animator;
    Vector2 MoveDirection;
    bool isDashing = false;
    BossManager bossManager;
    
    // Start is called before the first frame update
    void Start()
    {
        bossManager = GameManager.Instance.getBossManager();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
        mExpJamPoolController = GameManager.Instance.getExpJamPoolController();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(DashingPattern());
        MoveDirection = new Vector2();
        hp = 20;
    }

    IEnumerator DashingPattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Dash();
        }
    }

    private void Dash()
    {
        animator.SetBool("Dashing", true);
        StartCoroutine(Dashing());
    }

    IEnumerator Dashing()
    {
        isDashing = true;
        float dashingTime=0;
        int preAttackNum = attackNum;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            dashingTime += 0.1f;
            mRigid.velocity = MoveDirection * 10f;
            if (preAttackNum != attackNum | dashingTime >= 3)
            {
                animator.SetBool("Dashing", false);
                break;
            } 
        }
        isDashing = false;
    }


    private void Move()
    {
        float deltaX = playerTransform.position.x - transform.position.x;
        float deltaY = playerTransform.position.y - transform.position.y;
        float a = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        MoveDirection.x = deltaX / a;
        MoveDirection.y = deltaY / a;
        mRigid.velocity = MoveDirection;
    }

    void Update()
    { 
        if (!isDashing)
        {
            Move();
        }
        
        if (hp == 0)
        {
            bossManager.EndBossStage();
            Destroy(gameObject);
        }
    }
}

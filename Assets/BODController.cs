using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BODController : MonoBehaviour
{
    private Rigidbody2D mRigid;
    private Animator mAnimator;
    private float speed = 5;
    private int maxHp = 5;
    private int hp;
    private GameManager mGameManager;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        mRigid = this.GetComponent<Rigidbody2D>(); 
        mAnimator = GetComponentInChildren<Animator>();
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            direction = direction + new Vector2(0, 1);
            isWalking = true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            direction = direction + new Vector2(-1, 0);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = direction + new Vector2(0, -1);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = direction + new Vector2(1, 0);
            isWalking = true;
        }
        Move(direction, isWalking);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }

    public void SpawnPlayer()
    {
        gameObject.SetActive(true);
        hp = maxHp;
    }

    public void Damaged()
    {
        hp -= 1;
        mAnimator.SetTrigger("Hurt");
        print("Attacked");
        if (hp <= 0)
        {
            mGameManager.PlayerDead();
            this.gameObject.SetActive(false);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector3(this.mRigid.position.x +this.attackSensorPosX*transform.localScale.x*-1, this.mRigid.position.y + this.attackSensorPosY, 0), new Vector3(this.attackSensorHalfSizeX, this.attackSensorHalfSizeY, 1));
    }

    private float attackSensorPosX = 2.5f;
    private float attackSensorPosY = 0;
    private float attackSensorHalfSizeX = 3;
    private float attackSensorHalfSizeY = 3;

    IEnumerator Attacking(RaycastHit2D hit)
    {
        yield return new WaitForSeconds(0.5f);
        hit.collider.GetComponent<SlimeController>().Damaged();
    }

    private void Attack()
    {
        Vector2 curGroundSensorPos = new Vector2(
        this.mRigid.position.x + this.attackSensorPosX * transform.localScale.x*-1,
        this.mRigid.position.y + this.attackSensorPosY);

        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            curGroundSensorPos,
            new Vector2(attackSensorHalfSizeX, attackSensorHalfSizeY),
            0,
            new Vector2(0.0f, 0.0f)); ;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                StartCoroutine(Attacking(hit)); 
            }
        }
        mAnimator.SetTrigger("Attack");
    }

    private void Move(Vector2 direction, bool isWalking)
    {
        if (isWalking)
        {
            mRigid.velocity = speed * direction;
        } else
        {
            mRigid.velocity = new Vector2(0, 0);
        }

        if (direction.x != 0)
        {
            this.transform.localScale = new Vector3(-1 * direction.x, 1, 1);
        }
        
        mAnimator.SetBool("Walking", isWalking);
    }
}

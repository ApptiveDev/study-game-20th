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
    private HpBar hpBar;
    int damage = 1;
    int damageResist;
    int healPer5sec;
    private GameDataManager mGameDataManager;
    private GearAbility gearAbility;

    public int getHp()
    {
        return hp;
    }

    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    void Start()
    {
        mRigid = this.GetComponent<Rigidbody2D>(); 
        mAnimator = GetComponentInChildren<Animator>();
        mGameManager = GameManager.Instance;
        hpBar = mGameManager.getPlayerHp();
        mGameDataManager = GameDataManager.Instance;
        InitPlayerData();
        StartCoroutine(Healing());
    }

    private void InitPlayerData()
    {
        gearAbility = mGameDataManager.GetGearAbility();
        maxHp = mGameDataManager.GetHp() + gearAbility.additionalHp;
        speed = mGameDataManager.GetSpeed() + gearAbility.speed;
        hp = maxHp;
        damageResist = gearAbility.damageResist;
        healPer5sec = gearAbility.healPer5sec;
    }

    void Update()
    {
        ControllByKeyma();
    }

    private void ControllByKeyma()
    {
        Vector2 direction = new Vector2(0, 0);
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            direction = direction + new Vector2(0, 1);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.A))
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

    public void Damaged(int damage = 1)
    {
        hp -= Mathf.Max(0, damage - damageResist);
        hpBar.ChangeHpBar(hp);
        mAnimator.SetTrigger("Hurt");
        if (hp <= 0)
        {
            mGameManager.getTmpGameOver().GetComponent<GameOverController>().PlayerDead();
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Healing()
    {
        while (hp > 0 && hp < maxHp)
        {
            yield return new WaitForSeconds(5f);
            hp = Mathf.Min(maxHp, hp + healPer5sec);
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector3(this.mRigid.position.x +this.attackSensorPosX*transform.localScale.x*-1, this.mRigid.position.y + this.attackSensorPosY, 0), new Vector3(this.attackSensorHalfSizeX, this.attackSensorHalfSizeY, 1));
    }
    */

    private float attackSensorPosX = 2.5f;
    private float attackSensorPosY = 0;
    private float attackSensorHalfSizeX = 3;
    private float attackSensorHalfSizeY = 3;

    IEnumerator Attacking(RaycastHit2D hit)
    {
        yield return new WaitForSeconds(0.5f);
        hit.collider.GetComponent<Enemy>().Damaged(damage);
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

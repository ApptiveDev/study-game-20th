using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected int hp = 1;
    protected float speed = 1f;
    protected ObjectPoolController objectPoolController;
    protected ExpJamPoolController mExpJamPoolController;
    protected CoinPoolController mCoinPoolController;
    protected int attackNum = 0;
    protected Transform playerTransform;
    protected Rigidbody2D mRigid;
    protected GameManager gameManager;
    protected int damage = 1;

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        playerTransform = gameManager.getPlayer().GetComponent<Transform>();
        mRigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Move()
    {
        float deltaX = playerTransform.position.x - transform.position.x;
        float deltaY = playerTransform.position.y - transform.position.y;
        float a = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        mRigid.velocity = new Vector2(deltaX / a, deltaY / a);
    }


    public void Damaged(int damage = 1)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameManager.Instance.AddTokillEnemyCount(1);
            try
            {
                objectPoolController.AddToPool(this.gameObject);
                mCoinPoolController.DropExpJam(transform.position + Vector3.one * 2);
                mExpJamPoolController.DropExpJam(transform.position);
                this.gameObject.SetActive(false);
            }
            catch
            {
                Debug.Log("Enemy | Damaged : is Not use Object Pool");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BODController>().Damaged(damage);
            attackNum += 1;
        }
    }
}

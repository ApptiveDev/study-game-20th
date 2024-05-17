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
                print("isBoss");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BODController>().Damaged();
            attackNum += 1;
        }
    }
}

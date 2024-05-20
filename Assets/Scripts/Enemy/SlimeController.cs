using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : Enemy
{
    void Start()
    {
        base.Start();
        objectPoolController = GameManager.Instance.getGameManagement().GetComponent<SlimePoolController>();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
        mCoinPoolController = GameManager.Instance.getGameManagement().GetComponent<CoinPoolController>();
        mExpJamPoolController = GameManager.Instance.getExpJamPoolController();
    }

    private void Move()
    {
        base.Move();
    }   

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

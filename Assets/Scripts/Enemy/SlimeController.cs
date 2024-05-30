using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : Enemy
{
    void Start()
    {
        base.Start();
        objectPoolController = gameManager.getGameManagement().GetComponent<SlimePoolController>();
        mCoinPoolController = gameManager.getGameManagement().GetComponent<CoinPoolController>();
        mExpJamPoolController = gameManager.getExpJamPoolController();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpJam : Item
{
    ExpBar playerExp;
    int expValue = 3;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerExp = gameManager.getExpBar();
        itemPoolController = gameManager.getExpJamPoolController();
    }

    protected override void Update()
    {
        base.Update();
        if (isEaten)
        {
            AddExp();
            itemPoolController.AddToPool(gameObject);
            gameObject.SetActive(false);
        }
    }

    void AddExp()
    {
        playerExp.AddExpBar(expValue);
    }

}

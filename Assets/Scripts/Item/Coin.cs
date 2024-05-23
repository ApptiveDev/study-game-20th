using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : Item
{
    GameDataManager gameDataManager;
    int coinValue = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gameDataManager = GameDataManager.Instance;
        itemPoolController = gameManager.getGameManagement().GetComponent<CoinPoolController>();
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
        gameDataManager.SetCoin(gameDataManager.GetCoin() + coinValue);
    }
}

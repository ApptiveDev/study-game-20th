using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : Item
{
    GameDataController gameDataController;
    int coinValue = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gameDataController = GameDataController.Instance;
        itemPoolController = gameManager.getGameManager().GetComponent<CoinPoolController>();
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
        gameDataController.SetCoin(gameDataController.GetCoin() + coinValue);
    }
}

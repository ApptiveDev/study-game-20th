using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    int coin = 0;
    int maxHp = 10;
    float speed = 5;

    GameDataController gameDataController;

    private void Start()
    {
        gameDataController = GameDataController.Instance;
    }

    public void Save()
    {
        coin = gameDataController.GetCoin();
        maxHp = gameDataController.GetHp();
        speed = gameDataController.GetSpeed();

        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("maxHp", maxHp);
        PlayerPrefs.SetFloat("speed", speed);
    }

    public void Load()
    {
        coin = PlayerPrefs.GetInt("coin");
        maxHp = PlayerPrefs.GetInt("maxHp");
        speed = PlayerPrefs.GetFloat("speed");

        gameDataController.SetCoin(coin);
        gameDataController.SetHp(maxHp);
        gameDataController.SetSpeed(speed);
    }
}

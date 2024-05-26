using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    int coin = 0;
    int maxHp = 10;
    float speed = 5;

    GameDataManager gameDataManager;
    List<int> playerGears;

    private void Start()
    {
        gameDataManager = GameDataManager.Instance;
    }

    private void SavePlayerGearDatas()
    {
        playerGears = gameDataManager.GetPlayerGearData();
        for (int i = 0; i<17; i++)
        {
            PlayerPrefs.SetInt("Gear" + i, playerGears[i]);
        }
    }

    private void LoadPlayerGearDatas()
    {
        if (playerGears == null)
        {
            playerGears = new List<int>();
            for (int i = 0; i < 17; i++)
            {
                playerGears.Add(-1);
            }
        }

        for (int i = 0; i < 17; i++)
        {
            playerGears[i] = PlayerPrefs.GetInt("Gear" + i);
        }
        gameDataManager.SetPlayerGearData(playerGears);
    }

    public void Save()
    {

        SavePlayerGearDatas();

        coin = gameDataManager.GetCoin();
        maxHp = gameDataManager.GetHp();
        speed = gameDataManager.GetSpeed();

        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("maxHp", maxHp);
        PlayerPrefs.SetFloat("speed", speed);
    }

    public void Load()
    {
        LoadPlayerGearDatas();

        coin = PlayerPrefs.GetInt("coin");
        maxHp = PlayerPrefs.GetInt("maxHp");
        speed = PlayerPrefs.GetFloat("speed");

        gameDataManager.SetCoin(coin);
        gameDataManager.SetHp(maxHp);
        gameDataManager.SetSpeed(speed);
    }
}

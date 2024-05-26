using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{
    GameDataManager mGameDataManager;
    TMP_Text coinDisplayerText;

    private void Start()
    {
        mGameDataManager = GameDataManager.Instance;
        coinDisplayerText = GameObject.Find("CoinDisplayer").GetComponent<TMP_Text>() ;
        UpdateCoinDisplayer();
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    private void UpdateCoinDisplayer()
    {
        coinDisplayerText.SetText("Coin : " + mGameDataManager.GetCoin());
    }

    public void RandomGetGear()
    {
        if (mGameDataManager.GetCoin() - 10 >= 0)
        {
            List<int> playerGearData = mGameDataManager.GetPlayerGearData();

            int gearId = Random.Range(0, mGameDataManager.GetGearData().GetGearNum());
            bool isFull = true;

            for (int i = 3; i < 17; i++)
            {
                if (playerGearData[i] == -1)
                {
                    isFull = false;
                    playerGearData[i] = gearId;
                    break;
                }
            }

            if (!isFull)
            {
                mGameDataManager.SetCoin(mGameDataManager.GetCoin() - 10);
                mGameDataManager.SetPlayerGearData(playerGearData);
            }
        }
    }

    public void UpgradeHp()
    {
        if (mGameDataManager.GetCoin() - 10 >=0)
        {
            mGameDataManager.SetCoin(mGameDataManager.GetCoin() - 10);
            mGameDataManager.SetHp(mGameDataManager.GetHp() + 1);
            UpdateCoinDisplayer();
        }
    }

    public void UpgradeSpeed()
    {
        if (mGameDataManager.GetCoin() - 10 >= 0)
        {
            mGameDataManager.SetCoin(mGameDataManager.GetCoin() - 10);
            mGameDataManager.SetSpeed(mGameDataManager.GetSpeed() + 1);
            UpdateCoinDisplayer();
        }
        
    }
}

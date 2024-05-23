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

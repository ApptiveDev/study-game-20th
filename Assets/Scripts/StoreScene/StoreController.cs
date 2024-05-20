using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{
    GameDataController mGameDataController;
    TMP_Text coinDisplayerText;

    private void Start()
    {
        mGameDataController = GameDataController.Instance;
        coinDisplayerText = GameObject.Find("CoinDisplayer").GetComponent<TMP_Text>() ;
        UpdateCoinDisplayer();
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    private void UpdateCoinDisplayer()
    {
        coinDisplayerText.SetText("Coin : " + mGameDataController.GetCoin());
    }


    public void UpgradeHp()
    {
        mGameDataController.SetCoin(mGameDataController.GetCoin() - 10);
        mGameDataController.SetHp(mGameDataController.GetHp() + 1);
        UpdateCoinDisplayer();
    }

    public void UpgradeSpeed()
    {
        mGameDataController.SetSpeed(mGameDataController.GetSpeed() - 10);
        mGameDataController.SetHp(mGameDataController.GetHp() + 1);
        UpdateCoinDisplayer();
    }

}

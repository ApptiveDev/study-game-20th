using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{

    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStoreScene()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

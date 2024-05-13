using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    bool flag = true;

    void Update()
    {
        if (flag)
        {
            GameOverUI();
        }
    }

    void GameOverUI()
    {
        gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            flag = false;
        }
    }
}

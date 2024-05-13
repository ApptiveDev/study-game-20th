using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    bool flag = true;
    Character CH;
    
    void Update()
    {
        CH = GameObject.Find("Character").GetComponent<Character>();
        if (CH.GameOver && flag)
        {
            GameOverUI();
            flag = false;
        }
    }

    void GameOverUI()
    {
        gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}

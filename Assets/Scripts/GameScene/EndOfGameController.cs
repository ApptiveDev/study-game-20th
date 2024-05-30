using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfGameController: MonoBehaviour
{

    GameManager gameManager;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        text = gameObject.GetComponent<TMP_Text>();
        gameObject.SetActive(false);
    }

    public void GameClearOrOver(bool isGameClear)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        if (isGameClear)
        {
            text.text = "GameClear";
        } else
        {
            text.text = "GameOver";
        }
        StartCoroutine(GameEnd());
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        yield return new WaitUntil(() => Input.anyKey);

        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("LobbyScene");
        //gameManager.getPlayer().GetComponent<BODController>().SpawnPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController: MonoBehaviour
{

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        gameObject.SetActive(false);
    }

    public void PlayerDead()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        StartCoroutine(GameOvered());
    }

    IEnumerator GameOvered()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        yield return new WaitUntil(() => Input.anyKey);

        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("LobbyScene");
        //gameManager.getPlayer().GetComponent<BODController>().SpawnPlayer();
    }
}

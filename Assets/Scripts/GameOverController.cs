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
        print("tlqkf");
    }

    IEnumerator GameOvered()
    {
        yield return new WaitForSeconds(1.0f);
        print("tlqkf");
        while (true)
        {
            print("restart");
            if (Input.anyKey)
            {
                break;
               
            }
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
        print("restart");
        SceneManager.LoadScene("SceneByYS");


        //gameManager.getPlayer().GetComponent<BODController>().SpawnPlayer();

    }
}

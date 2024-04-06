using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject tmpGameOver;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        tmpGameOver = GameObject.Find("GameOver");
        tmpGameOver.SetActive(false);
        player = GameObject.Find("BOD");
    }

    public void PlayerDead()
    {
        tmpGameOver.SetActive(true); 
        Time.timeScale = 0.1f;
        //StartCoroutine(GameOvered());
    }
    IEnumerator GameOvered()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.anyKey)
            {
                break;
            }
        }
        tmpGameOver.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<BODController>().SpawnPlayer();
           
    }
}

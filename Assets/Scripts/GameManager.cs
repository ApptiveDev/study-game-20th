using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    private GameManager() { }


    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }
    HpBar playerHp;
    GameObject tmpGameOver;
    GameObject player;
    List<GameObject> enemyList = new List<GameObject>();
    public GameObject getPlayer()
    {
        return player;
    }

    public void addEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public List<GameObject> getEnemyList()
    {
        return enemyList;
    }

    public HpBar getPlayerHp()
    {
        return playerHp;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("PlayerHp").GetComponent<HpBar>();
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

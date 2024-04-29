using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    //private GameManager() { }

    public static GameManager Instance
    {
        get
        {

            //if (instance == null)
            //{
                //print("Create instance of GameManager");
                //instance = new GameManager();
            //}
            return instance ;
        }
    }
    HpBar playerHp;
    GameObject tmpGameOver;
    GameObject player;
    List<GameObject> enemyList = new List<GameObject>();
    GameObject mGameManager;
    GameObject camera;

    public void addEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public List<GameObject> getEnemyList()
    {
        return enemyList;
    }

    public GameObject getGameManager()
    {
        return mGameManager;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public HpBar getPlayerHp()
    {
        return playerHp;
    }

    public GameObject getCamera()
    {
        return camera;
    }

    public GameObject getTmpGameOver()
    {
        return tmpGameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        instance = gameObject.GetComponent<GameManager>();
        mGameManager = GameObject.Find("GameManagement");
        playerHp = GameObject.Find("PlayerHp").GetComponent<HpBar>();
        tmpGameOver = GameObject.Find("GameOver");
        player = GameObject.Find("BOD");
    }
    private void Update()
    {
        print("tlqkf GameManager running");
    }


}

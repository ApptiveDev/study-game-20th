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
    WeaponManager weaponManager;
    HpBar playerHp;
    ExpBar playerExp;
    GameObject tmpGameOver;
    GameObject player;
    List<GameObject> enemyList = new List<GameObject>();
    GameObject mGameManager;
    GameObject camera;
    ExpJamPoolController mExpJamPoolController;
    BossManager mBossManager;

    int killEnemyCount = 0;

    public void AddTokillEnemyCount(int num)
    {
        killEnemyCount += num;
        mBossManager.UpdateKillEnemyCount(killEnemyCount);
    }

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

    public ExpBar getExpBar()
    {
        return playerExp;
    }

    public ExpJamPoolController getExpJamPoolController()
    {
        return mExpJamPoolController;
    }

    public WeaponManager getWeaponManager()
    {
        return weaponManager;
    }

    private void Awake()
    {
        instance = this;
        weaponManager = GameObject.Find("WeaponSelect").GetComponent<WeaponManager>();
        camera = GameObject.Find("Main Camera");
        mGameManager = GameObject.Find("GameManagement");
        playerHp = GameObject.Find("PlayerHp").GetComponent<HpBar>();
        tmpGameOver = GameObject.Find("GameOver");
        player = GameObject.Find("BOD");
        playerExp = GameObject.Find("PlayerExp").GetComponent<ExpBar>();
        mExpJamPoolController = mGameManager.GetComponent<ExpJamPoolController>();
        mBossManager = mGameManager.GetComponent<BossManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance ;
        }
    }
    WeaponManager weaponManager;
    HpBar playerHp;
    ExpBar playerExp;
    GameObject tmpGameOver;
    GameObject player;
    List<GameObject> enemyList = new List<GameObject>();
    GameObject gameManagement;
    GameObject camera;
    ExpJamPoolController mExpJamPoolController;
    BossManager mBossManager;

    int killEnemyCount = 0;

    public BossManager getBossManager()
    {
        return mBossManager;
    }


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

    public GameObject getGameManagement()
    {
        return gameManagement;
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
        gameManagement = GameObject.Find("GameManagement");
        playerHp = GameObject.Find("PlayerHp").GetComponent<HpBar>();
        tmpGameOver = GameObject.Find("GameOver");
        player = GameObject.Find("BOD");
        playerExp = GameObject.Find("PlayerExp").GetComponent<ExpBar>();
        mExpJamPoolController = gameManagement.GetComponent<ExpJamPoolController>();
        mBossManager = gameManagement.GetComponent<BossManager>();
    }
}

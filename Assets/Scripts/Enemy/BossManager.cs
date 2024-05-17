using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    GameManager gameManager;
    GameObject gameManagement;

    [SerializeField] GameObject gateKeeper;
    GameObject temp;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManagement = gameManager.getGameManager();
        
    }

    public void UpdateKillEnemyCount(int count)
    {
        if (count >= 10 & temp == null)
        {   
            InitBossStage();
        }
    }

    void InitBossStage()
    {
        gameManagement.GetComponent<SlimePoolController>().SetSpawnObject(false);
        gameManagement.GetComponent<LongAttackEnemyPoolController>().SetSpawnObject(false);
        temp = Instantiate(gateKeeper, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void EndBossStage()
    {
        print("end");
        gameManagement.GetComponent<SlimePoolController>().SetSpawnObject(true);
        gameManagement.GetComponent<LongAttackEnemyPoolController>().SetSpawnObject(true);
    }

}

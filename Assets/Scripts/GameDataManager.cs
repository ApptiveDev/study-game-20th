using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataManager : MonoBehaviour
{

    [SerializeField] private GameDataContainer gameDataContainer;
    [SerializeField] private WeaponDataContainer weaponDataContainer;
    [SerializeField] private EnemyDataContainer enemyDataContainer;
    [SerializeField] private GearDataContainer gearDataContainer;

    private GearSceneManager gearSceneManager;

    private static GameDataManager instance = null;



    [SerializeField] private int hp = 10;
    [SerializeField] private float speed = 5;
    [SerializeField] private int coin = 0;
    [SerializeField] private List<int> playersGears = new List<int>();

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        InitData();
        if (gearSceneManager == null)
        {
            gearSceneManager = GearSceneManager.Instance;
        }
        
    }

    public List<int> GetPlayersGears()
    {
        return playersGears;
    }

    private void InitData()
    {
        hp = 10;
        coin = 0;
        speed = 5;

        for (int i = 0; i < 17; i++)
        {
            playersGears.Add(-1);
        }

    }

    public void SetPlayerGearData(List<int> playersGearData)
    {
        playersGears = playersGearData;
    }

    public GearDataContainer GetGearData()
    {
        return gearDataContainer;
    }

    public WeaponDataContainer GetWeaponData()
    {
        return weaponDataContainer;
    }

    public static GameDataManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SetCoin(int coin)
    {
        this.coin = coin;
    }

}

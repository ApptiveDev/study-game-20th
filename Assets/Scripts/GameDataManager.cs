using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GearAbility
{
    [SerializeField] public int healPer5sec;
    [SerializeField] public float speed;
    [SerializeField] public int damageResist;
    [SerializeField] public int additionalHp;
}

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
    [SerializeField] private GearAbility gearAbility = new GearAbility();

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitData();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
        if (gearSceneManager == null)
        {
            gearSceneManager = GearSceneManager.Instance;
        }
        
    }

    public GearAbility GetGearAbility()
    {
        return gearAbility;
    }

    public void SetGearAbility(GearAbility gearAbility)
    {
        this.gearAbility = gearAbility;
    }

    public List<int> GetPlayerGearData()
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

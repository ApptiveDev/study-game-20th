using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameDataContainer : ScriptableObject
{
    [SerializeField] private int pid { get; }

    [SerializeField] private int coin { get; set; }

    [SerializeField] private float speed = 1;
    [SerializeField] private int hp = 5;

    public void AddCoin(int coin)
    {
        this.coin += coin;
    }

    public void UseCoin(int coin)
    {
        this.coin -= coin;
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public int GetHp()
    {
        return hp;
    }
}

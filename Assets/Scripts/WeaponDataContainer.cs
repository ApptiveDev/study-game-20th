using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct WeaponData
{
    [SerializeField] public int id;
    [SerializeField] public GameObject prefab;
    [SerializeField] public Sprite sprite;
    [SerializeField] public string upgradeExplainString;
}


[CreateAssetMenu]
public class WeaponDataContainer : ScriptableObject
{
    [SerializeField] WeaponData swords = new WeaponData();
    [SerializeField] WeaponData glops = new WeaponData();
    [SerializeField] WeaponData player = new WeaponData();
    [SerializeField] WeaponData jars = new WeaponData();

    List<WeaponData> weaponDatas = new List<WeaponData>();
    

    public WeaponData GetWeaponData(int n)
    {
        if (weaponDatas.Count == 0)
        {
            InitList();
        }

        return weaponDatas[n];
    }

    public int GetWeaponNum()
    {
        if (weaponDatas.Count == 0)
        {
            InitList();
        }
        return weaponDatas.Count;
    }

    private void InitList()
    {
        weaponDatas.Add(swords);
        weaponDatas.Add(glops);
        weaponDatas.Add(player);
        weaponDatas.Add(jars);
    }
}

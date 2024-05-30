using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct GearData
{
    [SerializeField] public int id;
    [SerializeField] public int gearTypeId; // 0 : head // 1 : body // 2 : foot
    [SerializeField] public GameObject prefab;
    [SerializeField] public string gearExplain;
    [SerializeField] public int healPer5sec;
    [SerializeField] public float speed;
    [SerializeField] public int damageResist;
    [SerializeField] public int additionalHp;
}


[CreateAssetMenu]
public class GearDataContainer : ScriptableObject
{
    [SerializeField] GearData IronArmor = new GearData();
    [SerializeField] GearData IronBoot = new GearData();
    [SerializeField] GearData Helm = new GearData();
    [SerializeField] GearData LeatherArmor = new GearData();
    [SerializeField] GearData LeatherBoot = new GearData();
    [SerializeField] GearData LeatherHelmet = new GearData();
    [SerializeField] GearData WizardHat = new GearData();
    [SerializeField] GearData WoodenArmor = new GearData();


    List<GearData> gearDatas = new List<GearData>();


    public GearData GetGearData(int n)
    {
        if (n == -1)
        {
            return new GearData();
        }
        if (gearDatas.Count == 0)
        {
            InitList();
        }
        
        return gearDatas[n];
    }

    public int GetGearNum()
    {
        if (gearDatas.Count == 0)
        {
            InitList();
        }
        return gearDatas.Count;
    }

    private void InitList()
    {
        gearDatas.Add(IronArmor);
        gearDatas.Add(IronBoot);
        gearDatas.Add(Helm);
        gearDatas.Add(LeatherArmor);
        gearDatas.Add(LeatherBoot);
        gearDatas.Add(LeatherHelmet);
        gearDatas.Add(WizardHat);
        gearDatas.Add(WoodenArmor);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class GearSpace
{
    [SerializeField] public int id;
    [SerializeField] public Vector3 position;
    [SerializeField] public bool isContain;

    public GearSpace(int pid, Vector3 pposition, bool pisContain)
    {
        id = pid;
        position = pposition;
        isContain = pisContain;
    }

    public void GearOut()
    {
        isContain = false;
    }

    public void GearIn()
    {
        isContain = true;
    }

}

public class GearSceneManager : MonoBehaviour
{
    public static GearSceneManager instance = null;
    public static GearSceneManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitLists();
    }

    List<GameObject> gearInventorys;
    [SerializeField] List<GearSpace> gearSpaces;


    void InitLists()
    {
        gearInventorys = new List<GameObject>(GameObject.FindGameObjectsWithTag("GearInventory"));
        gearSpaces = new List<GearSpace>();

        gearInventorys.Sort((a, b) =>
        {
            int compareY = b.transform.position.y.CompareTo(a.transform.position.y);
            if (compareY == 0)
            {
                return a.transform.position.x.CompareTo(b.transform.position.x);
            }
            return compareY;
        });

        int i = 0;
        foreach (GameObject gearSpace in gearInventorys)
        {
            gearSpaces.Add(new GearSpace(i, gearSpace.transform.position, false));
            i++;
        }
    }

    public GearSpace GetMostCloseSpace(Vector3 position)
    {
        int closeSpaceIndex = -1;
        float leastDistence = float.MaxValue;

        for (int i = 0; i < gearSpaces.Count; i++)
        {
            
            float temp = Mathf.Pow(position.x - gearSpaces[i].position.x, 2) + Mathf.Pow(position.y - gearSpaces[i].position.y, 2);
            if (temp < leastDistence && !gearSpaces[i].isContain)
            {
                leastDistence = temp;
                closeSpaceIndex = i;
            }
        }

        gearSpaces[closeSpaceIndex].GearIn();

        return gearSpaces[closeSpaceIndex];
    }

    public void GearOut(int spaceId)
    {
        gearSpaces[spaceId].GearOut();
    }

}

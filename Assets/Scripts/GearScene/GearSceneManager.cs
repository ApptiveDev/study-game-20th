using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[Serializable]
public class GearSpace
{
    [SerializeField] public int id;
    [SerializeField] public Vector3 position;
    [SerializeField] public bool isContain;
    [SerializeField] public int gearId;

    public GearSpace(int pid, Vector3 pposition, bool pisContain)
    {
        id = pid;
        position = pposition;
        isContain = pisContain;
    }

    public void GearOut()
    {
        gearId = -1;
        isContain = false;
    }

    public void GearIn(int pGearId)
    {
        gearId = pGearId;
        isContain = true;
    }

}

public class GearSceneManager : MonoBehaviour
{

    [SerializeField] GameObject gearExplainPage;

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
    List<int> playersGears;
    GameDataManager gameDataManager;
    GearDataContainer gearDataContainer;

    public void SetGearExplainPage(bool active, string text = " ", Vector3 position = default(Vector3))
    {
        Vector3 temp = new Vector3(2, 0, 5) + position;

        gearExplainPage.SetActive(active);
        if (active)
        {
            gearExplainPage.transform.position = temp;
            gearExplainPage.GetComponentInChildren<TMP_Text>().SetText(text);
        }
    }


    private void Start()
    {
        gameDataManager = GameDataManager.Instance;
        gearDataContainer = gameDataManager.GetGearData();
        InitGears();
        SetGearExplainPage(false);
    }


    void InitGears()
    {
        playersGears = gameDataManager.GetPlayerGearData();

        for (int i = 0;  i<17; i++)
        {
            if (playersGears[i] != -1)
            {
                GearData gearData = gearDataContainer.GetGearData(playersGears[i]);
                GameObject temp = Instantiate(gearData.prefab, gearSpaces[i].position + new Vector3(0, 0, -90), Quaternion.identity);
                temp.GetComponent<GearItem>().SetGearData(gearData.id, gearData.gearTypeId, i, gearData.gearExplain);
                gearSpaces[i].GearIn(gearData.id);

            }
        }
    }



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


    public GearSpace GetMostCloseSpace(Vector3 position, int gearId, int gearTypeId)
    {
        int closeSpaceIndex = -1;
        float leastDistence = float.MaxValue;


        for (int i = 0; i < 3; i++)
        {
            if (i == gearTypeId)
            {
                float temp = Mathf.Pow(position.x - gearSpaces[i].position.x, 2) + Mathf.Pow(position.y - gearSpaces[i].position.y, 2);
                if (temp < leastDistence && !gearSpaces[i].isContain)
                {
                    leastDistence = temp;
                    closeSpaceIndex = i;
                }
            }  
        }


        for (int i = 3; i < gearSpaces.Count; i++)
        {

            
            float temp = Mathf.Pow(position.x - gearSpaces[i].position.x, 2) + Mathf.Pow(position.y - gearSpaces[i].position.y, 2);
            if (temp < leastDistence && !gearSpaces[i].isContain)
            {
                leastDistence = temp;
                closeSpaceIndex = i;
            }
        }

        gearSpaces[closeSpaceIndex].GearIn(gearId);

        return gearSpaces[closeSpaceIndex];
    }


    public void GearOut(int spaceId)
    {
        gearSpaces[spaceId].GearOut();
    }


    private void UpdatePlayerGearDatas()
    {
        for (int i = 0; i < 17; i++)
        {
            if (gearSpaces[i].isContain)
            {
                playersGears[i] = gearSpaces[i].gearId;
            } else
            {
                playersGears[i] = -1;
            }
            
        }
        
    }


    public void LoadLobbyScene()
    {
        UpdatePlayerGearDatas();
        gameDataManager.SetPlayerGearData(playersGears);
        SceneManager.LoadScene("LobbyScene");
    }
}

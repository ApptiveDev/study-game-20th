using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : ObjectPoolController
{
    int num = 0;
    [SerializeField] GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        MakeObjects(sword, 6);
        setNumOfSwords(num);
    }

    public int getNumOfSword()
    {
        return num;
    }

    public void setNumOfSwords(int num)
    {
        this.num = num;
        float angleTerm = 2*Mathf.PI / num;
        for (int i =0; i <num; i++)
        {
            ObjectPool[i].SetActive(true);
            ObjectPool[i].GetComponent<Sword>().setAngle(i * angleTerm);
        }
        for (int i = num; i<6; i++)
        {
            ObjectPool[i].SetActive(false);
        }
    }
}

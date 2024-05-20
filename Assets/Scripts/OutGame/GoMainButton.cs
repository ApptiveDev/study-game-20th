using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainButton : MonoBehaviour
{
    public GameObject Main;
    public void GoMain()
    {
        GameObject.Find("Shop").SetActive(false);
        Main.SetActive(true);
    }
}

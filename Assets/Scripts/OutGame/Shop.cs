using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static float TotalPoint = 0f;
    [SerializeField] private Text PointText;

    void Update()
    {
        // PlayerPrefs.SetFloat("TotalPoint", TotalPoint);
        // TotalPoint = PlayerPrefs.GetFloat("TotalPoint");
        PointText.text = ("Point : "+TotalPoint).ToString();
    }
}

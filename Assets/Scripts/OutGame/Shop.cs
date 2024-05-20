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
        TotalPoint = ClearButton.TotalPoint;
        PointText.text = TotalPoint.ToString();
    }
}

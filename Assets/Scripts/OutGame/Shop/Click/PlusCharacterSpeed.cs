using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusCharacterSpeed : MonoBehaviour
{
    public static float SpeedPlus = 0;

    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            SpeedPlus += 0.5f;
            Shop.TotalPoint -= 10;
        }
    }
}

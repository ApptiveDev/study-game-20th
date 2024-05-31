using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusCharacterSpeed : MonoBehaviour
{
    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            Character.Speed += 0.5f;
            Shop.TotalPoint -= 10;
        }
    }
}

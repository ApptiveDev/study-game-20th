using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusFireDamage : MonoBehaviour
{
    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            Character.FireDamage++;
            Shop.TotalPoint -= 10;
        }
    }
}

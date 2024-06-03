using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusFireDamage : MonoBehaviour
{
    public static int FireDamagePlus = 0;
    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            FireDamagePlus++;
            Shop.TotalPoint -= 10;
        }
    }
}

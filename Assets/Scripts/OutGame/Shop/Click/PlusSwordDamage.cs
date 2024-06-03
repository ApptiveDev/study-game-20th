using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSwordDamage : MonoBehaviour
{
    public static int SwordDamagePlus = 0;
    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            SwordDamagePlus++;
            Shop.TotalPoint -= 10;
        }
    }
}

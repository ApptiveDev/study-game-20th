using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSwordDamage : MonoBehaviour
{
    public void Click()
    {
        if (Shop.TotalPoint >= 10)
        {
            Character.SwordDamage++;
            Shop.TotalPoint -= 10;
        }
    }
}

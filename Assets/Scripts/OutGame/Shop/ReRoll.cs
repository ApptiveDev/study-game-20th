using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReRoll : MonoBehaviour
{
    public void ReRolling()
    {
        //if (Shop.TotalPoint >= 1)
        //{
            FindObjectOfType<Shop>().RandomItems();
        //    Shop.TotalPoint--;
        //}
    }
}

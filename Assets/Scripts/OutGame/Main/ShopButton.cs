using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject Shop;
    public void GoShop()
    {   

        GameObject.Find("Main").SetActive(false);
        Shop.SetActive(true);
    }
}

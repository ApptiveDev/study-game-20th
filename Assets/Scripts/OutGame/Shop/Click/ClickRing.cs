using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickRing : MonoBehaviour
{
    [SerializeField] private Sprite SoldOutImage;
    [SerializeField] private Button Ring;
    private bool flag = true;
    public static int FireDamageMul = 1;

    public void Click()
    {
        if (flag && Shop.TotalPoint >= 10)
        {
            GetComponent<Image>().sprite = SoldOutImage;
            flag = false;
            FireDamageMul += 1;

            foreach (Transform child in Ring.transform)
            {
                child.gameObject.SetActive(false);
            }

            Shop.TotalPoint -= 10;
        }
    }
}

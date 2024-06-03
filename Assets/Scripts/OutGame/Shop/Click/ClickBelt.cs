using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBelt : MonoBehaviour
{
    [SerializeField] private Sprite SoldOutImage;
    [SerializeField] private Button Belt;
    private bool flag = true;
    public static float MaxHpMul = 1f;

    public void Click()
    {
        if (flag && Shop.TotalPoint >= 10)
        {
            GetComponent<Image>().sprite = SoldOutImage;
            flag = false;
            MaxHpMul += 0.5f;

            foreach (Transform child in Belt.transform)
            {
                child.gameObject.SetActive(false);
            }

            Shop.TotalPoint -= 10;
        }
    }
}

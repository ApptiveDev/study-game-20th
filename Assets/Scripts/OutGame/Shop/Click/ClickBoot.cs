using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBoot : MonoBehaviour
{
    [SerializeField] private Sprite SoldOutImage;
    [SerializeField] private Button Boot;
    private bool flag = true;
    public static float SpeedMul = 1f;

    public void Click()
    {
        if (flag) // && Shop.TotalPoint >= 10)
        {
            GetComponent<Image>().sprite = SoldOutImage;
            flag = false;
            SpeedMul += 0.5f;

            foreach (Transform child in Boot.transform)
            {
                child.gameObject.SetActive(false);
            }

            //Shop.TotalPoint -= 10;
        }
    }
}

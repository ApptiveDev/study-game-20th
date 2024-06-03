using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickGlove : MonoBehaviour
{
    [SerializeField] private Sprite SoldOutImage;
    [SerializeField] private Button Glove;
    private bool flag = true;
    public static int SwordDamageMul = 1;

    public void Click()
    {
        if (flag) // && Shop.TotalPoint >= 10)
        {
            GetComponent<Image>().sprite = SoldOutImage;
            flag = false;
            SwordDamageMul += 1;

            foreach (Transform child in Glove.transform)
            {
                child.gameObject.SetActive(false);
            }

            //Shop.TotalPoint -= 10;
        }
    }
}

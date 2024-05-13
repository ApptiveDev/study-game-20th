using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPIndicator : MonoBehaviour
{

    [SerializeField] Image remainHP;

    public void SetIndicator(float amount)
    {
        remainHP.fillAmount = amount;
    }

}

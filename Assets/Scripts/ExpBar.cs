using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    Slider slider;
    int exp = 0;
    WeaponManager weaponManager;

    public void AddExpBar(int i)
    {
        exp += i;
        while (exp >= slider.maxValue)
        {
            LevelUp();
            
            exp -= (int) slider.maxValue;
        }
        slider.value = exp;
        
    }

    void LevelUp()
    {
        print("Level Up");
        weaponManager.WeaponSelect();
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameManager.Instance.getWeaponManager();
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

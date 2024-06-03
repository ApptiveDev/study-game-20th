using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void StartGame()
    {
        Character.MaxHp *= ClickBelt.MaxHpMul;

        Character.Speed += PlusCharacterSpeed.SpeedPlus;
        Character.Speed *= ClickBoot.SpeedMul;
        
        Character.SwordDamage += PlusSwordDamage.SwordDamagePlus;
        Character.SwordDamage *= ClickGlove.SwordDamageMul;

        Character.FireDamage += PlusFireDamage.FireDamagePlus;
        Character.FireDamage *= ClickRing.FireDamageMul;
        
        SceneManager.LoadScene("InGameScene");
    }
}

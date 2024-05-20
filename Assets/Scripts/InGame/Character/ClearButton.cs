using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearButton : MonoBehaviour
{
    float PointPlus;
    public static float TotalPoint;
    RotatingWeapon RW;
    Character CH;
    WeaponSpawner WS;

    public void Clear()
    {
        PointPlus = Character.Point;
        TotalPoint = Shop.TotalPoint + PointPlus;
        PlayerPrefs.SetFloat("TotalPoint",TotalPoint);
        ClearComponent();
        Time.timeScale = 1f;
        SceneManager.LoadScene("OutGameScene");
    }

    void ClearComponent()
    {
        RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
        CH = GameObject.Find("Character").GetComponent<Character>();
        WS = GameObject.Find("WeaponSpawner").GetComponent<WeaponSpawner>();
        RW.Level = 0;
        CH.Level = 0;
        CH.Exp = 0;
        CH.Speed = 1;
        Character.Point = 0;
        FireBombSpawner.SpawnTime = 2f;
    }
}

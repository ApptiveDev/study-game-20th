using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    RotatingWeapon RW;
    Character CH;
    WeaponSpawner WS;

    public void Quit()
    {
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
        Character.Speed = 1;
        Character.Point = 0;
        FireBombSpawner.SpawnTime = 2f;
    }
}

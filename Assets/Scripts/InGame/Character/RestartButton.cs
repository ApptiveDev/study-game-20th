using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    
    RotatingWeapon RW;
    Character CH;
    WeaponSpawner WS;
    public void Restart()
    {
        Time.timeScale = 1f;
        GameObject.Find("GameOver").SetActive(false);
        ClearComponent();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void ClearComponent()
    {
        RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
        CH = GameObject.Find("Character").GetComponent<Character>();
        WS = GameObject.Find("WeaponSpawner").GetComponent<WeaponSpawner>();
        RW.Level = 0;
        CH.Level = 0;
        CH.Exp = 0;
        Character.Speed = 1 + PlusCharacterSpeed.SpeedPlus;
        Character.Point = 0;
        FireBombSpawner.SpawnTime = 2f;
    }
}

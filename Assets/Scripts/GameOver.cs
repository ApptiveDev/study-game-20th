using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    RotatingWeapon RW;
    Character CH;
    WeaponSpawner WS;
    bool flag = true;

    void Update()
    {
        if (flag)
        {
            GameOverUI();
        }
    }

    void GameOverUI()
    {
        gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            flag = false;
        }
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
        WS.weapons = new GameObject[5];
        FireBombSpawner.SpawnTime = 2f;
    }
}

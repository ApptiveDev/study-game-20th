using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OutGameScene");
    }
}

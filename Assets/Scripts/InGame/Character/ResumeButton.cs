using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
        GameObject.Find("GamePause").SetActive(false);
    }
}

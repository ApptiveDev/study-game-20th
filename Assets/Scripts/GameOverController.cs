using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController: MonoBehaviour
{

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDead()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        StartCoroutine(GameOvered());
    }

    IEnumerator GameOvered()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.anyKey)
            {
                break;
            }
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
        gameManager.getPlayer().GetComponent<BODController>().SpawnPlayer();

    }
}

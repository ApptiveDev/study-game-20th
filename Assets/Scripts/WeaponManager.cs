using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    GameManager gameManager;
    GlopPoolController glop;
    Swords swords;
    BODController player;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    int numSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.getPlayer().GetComponent<BODController>();
        glop = gameManager.getPlayer().GetComponent<GlopPoolController>();
        swords = gameManager.getPlayer().GetComponent<Swords>();
        gameObject.SetActive(false);
    }

    
    public void WeaponSelect()
    {
        numSelect += 1;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Weapon1()
    {
        swords.setNumOfSwords(swords.getNumOfSword() + 1);
        numSelect -= 1;
        if (numSelect != 0)
            return;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Weapon2()
    {
        glop.setShotGlopTime(glop.getShotGlopTime() - 1);
        numSelect -= 1;
        if (numSelect != 0)
            return;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Weapon3()
    {
        player.setDamage(player.getDamage() + 1);
        numSelect -= 1;
        if (numSelect != 0)
            return;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

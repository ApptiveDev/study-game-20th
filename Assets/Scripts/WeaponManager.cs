using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    GameManager gameManager;
    GlopPoolController glop;
    Swords swords;
    BODController player;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;

    [SerializeField] Sprite swordSprite;
    [SerializeField] Sprite glopSprite;
    [SerializeField] Sprite playerSprite;

    
    int numSelect = 0;
    List<int> weapons = new List<int>();
    List<int> selectedNumbers = new List<int>();
    List<Sprite> sprites = new List<Sprite>();
    List<GameObject> Buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.getPlayer().GetComponent<BODController>();
        glop = gameManager.getPlayer().GetComponent<GlopPoolController>();
        swords = gameManager.getPlayer().GetComponent<Swords>();
        initLists();
        gameObject.SetActive(false);
    }

    void initLists()
    {
        for (int i =0; i<3; i++)
        {
            weapons.Add(i);
        }

        sprites.Add(swordSprite);
        sprites.Add(glopSprite);
        sprites.Add(playerSprite);

        Buttons.Add(Button1);
        Buttons.Add(Button2);
        Buttons.Add(Button3);
    }
    
    public void ShowWeaponSelectPage()
    {
        randomlySelectWeapon3();
        numSelect += 1;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void randomlySelectWeapon3()
    { 
        while (selectedNumbers.Count < 3)
        {
            int randomNumber = Random.Range(0, weapons.Count); // 예를 들어, 1부터 10까지의 숫자를 랜덤으로 선택
            if (!selectedNumbers.Contains(randomNumber))
            {
                selectedNumbers.Add(randomNumber);
            }
        }

        for (int i=0; i<3; i++)
        {
            Buttons[i].GetComponent<Button>().image.sprite = sprites[selectedNumbers[i]];
        }
    }

    
    private void selectWeapon(int num)
    { 
        switch (num)
        {
            case 0 :
                swords.setNumOfSwords(swords.getNumOfSword() + 1);
                break;

            case 1:
                glop.setShotGlopTime(glop.getShotGlopTime() - 1);
                break;

            case 2:
                player.setDamage(player.getDamage() + 1);
                break;

            default:
                break;
        }

        numSelect -= 1;
        if (numSelect != 0)
        {
            randomlySelectWeapon3();
            return;
        }
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Weapon1()
    {
        selectWeapon(selectedNumbers[0]);
        
    }

    public void Weapon2()
    {
        selectWeapon(selectedNumbers[1]);
    }

    public void Weapon3()
    {
        selectWeapon(selectedNumbers[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

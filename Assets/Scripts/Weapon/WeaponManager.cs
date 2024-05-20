using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    GameManager gameManager;
    GlopPoolController glop;
    Swords swords;
    BODController player;
    JarPoolController jar;
    WeaponDataContainer weaponDataContainer;
    [SerializeField] Button Button1;
    [SerializeField] Button Button2;
    [SerializeField] Button Button3;
    [SerializeField] TMP_Text text1;
    [SerializeField] TMP_Text text2;
    [SerializeField] TMP_Text text3;

    [SerializeField] Sprite swordSprite;
    [SerializeField] Sprite glopSprite;
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite jarSprite;
    
    int numSelect = 0;
    List<int> weapons = new List<int>();
    List<int> selectedNumbers = new List<int>();
    List<Sprite> sprites = new List<Sprite>();
    List<Button> Buttons = new List<Button>();
    List<string> WeaponExplain = new List<string>();
    List<TMP_Text> Texts = new List<TMP_Text>();

    List<WeaponData> weaponDatas = new List<WeaponData>();
    int numOfWeapons;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.getPlayer().GetComponent<BODController>();
        glop = gameManager.getPlayer().GetComponent<GlopPoolController>();
        jar = gameManager.getPlayer().GetComponent<JarPoolController>();
        swords = gameManager.getPlayer().GetComponent<Swords>();
        weaponDataContainer = GameDataController.Instance.GetWeaponData();
        initDatas();
        gameObject.SetActive(false);
    }

    void initDatas()
    {
        numOfWeapons = weaponDataContainer.GetWeaponNum();


        for (int i =0; i < numOfWeapons; i++)
        {
            weaponDatas.Add(weaponDataContainer.GetWeaponData(i));
            weapons.Add(i);
            sprites.Add(weaponDatas[i].sprite);
            WeaponExplain.Add(weaponDatas[i].upgradeExplainString);
            print(i);
        }
        

        Buttons.Add(Button1);
        Buttons.Add(Button2);
        Buttons.Add(Button3);

        Texts.Add(text1);
        Texts.Add(text2);
        Texts.Add(text3);
    }


    void randomlySelectWeapon3()
    {
        selectedNumbers.Clear();

        while (selectedNumbers.Count < 3)
        {
            int randomNumber = Random.Range(0, weapons.Count); // 예를 들어, 1부터 10까지의 숫자를 랜덤으로 선택
            if (!selectedNumbers.Contains(randomNumber))
            {
                selectedNumbers.Add(randomNumber);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            Buttons[i].image.sprite = sprites[selectedNumbers[i]];
            Texts[i].text = WeaponExplain[selectedNumbers[i]];
        }
    }

    public void ShowWeaponSelectPage()
    {
        randomlySelectWeapon3();
        numSelect += 1;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
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
            case 3:
                jar.setShotJarTime(jar.getShotJarTime() + 1);
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

    public void OnButtonClick(int num)
    {
        selectWeapon(selectedNumbers[num]);
    }
}

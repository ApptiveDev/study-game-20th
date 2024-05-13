using UnityEngine;
public class WeaponSelectionManager : MonoBehaviour
{
    public static WeaponSelectionManager Instance;
    GameObject weapon;

    public WeaponSpawner weaponSpawner;

    void Start()
    {
        weaponSpawner = GetComponent<WeaponSpawner>();
    }

    // 무기 선택창 열기
    public void OpenWeaponSelection()
    {
        int playerLevel = Character.Level;

        if (playerLevel == 2)
        {
            weaponSpawner.SpawnWeapons();
        }
        else
        {
            //UpgradeWeapon(0);
            weaponSpawner.SpawnWeapons();
        }
    }

    /*private void UpgradeWeapon(int index)
    {
        GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
        if (weapon = null)
        {
            weapon.LevelUp();
        }
    }
    */
}
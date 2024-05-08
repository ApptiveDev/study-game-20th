using UnityEngine;

public class ExpObject : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Character.Exp++;
            if (Character.Exp > Character.MaxExp)
            {
                Character.Level++;
                WeaponSelectionManager.Instance.OpenWeaponSelection();
                Character.Exp = 0;
            }
            Destroy(gameObject);
        }
    }
}
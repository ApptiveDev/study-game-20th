using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRotatingWeapon : MonoBehaviour, IPointerClickHandler
{
    RotatingWeapon RW;
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
            RW.Level++;
            FindObjectOfType<WeaponSpawner>().SpawnWeapon();
            transform.position = new Vector3(169.66f,-524,0);
            GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(169.66f,-524,0);
            Time.timeScale = 1f;
        }
    }
}

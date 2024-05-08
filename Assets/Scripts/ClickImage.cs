using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("You Cliked Image1");
            Character.Level++;
            FindObjectOfType<WeaponSpawner>().SpawnWeapon();
            transform.position = new Vector3(222,-661,0);
            Time.timeScale = 1f;
        }
    }
}

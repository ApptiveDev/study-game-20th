using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFireMagic : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            FireBombSpawner.SpawnTime -= 0.5f;
            GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(169.66f,-524,0);
            GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(169.66f,-524,0);
            transform.position = new Vector3(169.66f,-524,0);
            Time.timeScale = 1f;
        }
    }
}

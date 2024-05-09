using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSpeedUp : MonoBehaviour, IPointerClickHandler
{
    Character C;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            C = GameObject.Find("Character").GetComponent<Character>();
            C.Speed += 0.2f;
            GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(169.66f,-524,0);
            transform.position = new Vector3(169.66f,-524,0);
            Time.timeScale = 1f;
        }
    }
}

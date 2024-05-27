using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSpeedUp : MonoBehaviour, IPointerClickHandler
{
    Character CH;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CH = GameObject.Find("Character").GetComponent<Character>();
            Character.Speed += 0.2f;
            GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(169.66f,-524,0);
            GameObject.FindGameObjectWithTag("Image3").transform.position = new Vector3(169.66f,-524,0);
            transform.position = new Vector3(169.66f,-524,0);
            Time.timeScale = 1f;
        }
    }
}

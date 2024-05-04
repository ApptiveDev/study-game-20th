using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWeapon : MonoBehaviour
{
    float circleR = 2.3f; //반지름
    float deg = 0; //각도
    float objSpeed = 400f; //원운동 속도

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        deg+= Time.deltaTime*objSpeed;
        if (player != null) {
            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                transform.position = player.transform.position + new Vector3(-x * circleR, y * circleR);
                transform.rotation = Quaternion.Euler(0, 0, deg * -1); //가운데를 바라보게 각도 조절
            } 
            else
            {
                deg = 0;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}

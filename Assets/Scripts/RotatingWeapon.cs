using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWeapon : MonoBehaviour
{
    float circleR = 4f; //반지름
    float deg = 0; //각도
    float objSpeed = 400f; //원운동 속도
    public int Level = 0;
    private WeaponSpawner WS;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        WS = GameObject.Find("WeaponSpawner").GetComponent<WeaponSpawner>();
        GameObject[] weapons = WS.weapons;

        deg += Time.deltaTime*objSpeed;
        if (player != null) {
            if (deg < 360)
            {
                 for (int i = 0; i < Level+1; i++)
                {
                    var rad = Mathf.Deg2Rad * (deg+(i*(360/(Level+1))));
                    var x = circleR * Mathf.Sin(rad);
                    var y = circleR * Mathf.Cos(rad);
                    weapons[i].transform.position = player.transform.position + new Vector3(x, y);
                    weapons[i].transform.rotation = Quaternion.Euler(0, 0, -(deg + (i * (360 / (Level+1)))));
                }
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

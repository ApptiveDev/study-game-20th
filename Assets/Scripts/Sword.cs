using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    Transform mTransform;
    Transform playerTransform;
    float angle = 0;
    float distance = 3;

    public void setAngle(float angle)
    {
        this.angle = angle;
    }

    // Start is called before the first frame update
    void Start()
    {
        mTransform = GetComponent<Transform>();
        playerTransform = GameObject.Find("BOD").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mTransform.position = new Vector3(Mathf.Sin(angle) * distance + playerTransform.position.x,
            Mathf.Cos(angle) * distance + playerTransform.position.y, 0);
        angle += 3 * Time.deltaTime;

        mTransform.RotateAround(new Vector3(0, 0, 1), 10* Time.deltaTime);
    }
}

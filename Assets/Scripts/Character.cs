using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{    void Update()
    {
        // Vector3 clampedPosition = transform.position;
        // clampedPosition.x = Mathf.Clamp(clampedPosition.x, -16f, 16f);
        // clampedPosition.y = Mathf.Clamp(clampedPosition.y, -9.6f, 5.25f);
        // transform.position = clampedPosition;

        if (Input.GetKey (KeyCode.LeftArrow)) {
            this.transform.Translate (-0.1f,0f,0f);
        }

        if (Input.GetKey (KeyCode.RightArrow)) {
            this.transform.Translate (0.1f,0f,0f);
        }

        if (Input.GetKey (KeyCode.UpArrow)) {
            this.transform.Translate (0f,0.1f,0f);
        }

        if (Input.GetKey (KeyCode.DownArrow)) {
            this.transform.Translate (0f,-0.1f,0f);
        }

        if (transform.position.x < -16) {
            transform.position = new Vector3(-16,transform.position.y,0);
        }

        if (transform.position.x > 16) {
            transform.position = new Vector3(16,transform.position.y,0);
        }

        if (transform.position.y < -9.6) {
            transform.position = new Vector3(transform.position.x,-9.6f,0);
        }

        if (transform.position.y > 5.25f) {
            transform.position = new Vector3(transform.position.x,5.25f,0);
        }
    }
}

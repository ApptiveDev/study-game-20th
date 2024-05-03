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

        Vector2 vec = new Vector2(0f,0f);

        if (Input.GetKey (KeyCode.LeftArrow)) {
            vec.x = -1f;
        }

        if (Input.GetKey (KeyCode.RightArrow)) {
            vec.x = 1f;
        }

        if (Input.GetKey (KeyCode.UpArrow)) {
            vec.y = 1f;
        }

        if (Input.GetKey (KeyCode.DownArrow)) {
            vec.y = -1f;
        }

        transform.Translate(vec.normalized * Time.deltaTime * 8f);

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

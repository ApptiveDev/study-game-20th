using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Vector3 moveVector;
    [SerializeField] float damage = 10f;

    const float THRESHOLD_Y = -20f;

    [SerializeField] float xSpeedBoundary = 1f;
    [SerializeField] float upwardForce = 1f;
    [SerializeField] float gravity = 2f;

    float xSpeed;
    float ySpeed;
    private void Start()
    {
        xSpeed = Random.Range(-xSpeedBoundary, xSpeedBoundary);
        ySpeed = upwardForce;
    }

    void Update()
    {
        if(transform.position.y <= THRESHOLD_Y)
        {
            gameObject.SetActive(false);
        }

        moveVector = new Vector3(xSpeed,ySpeed);
        transform.position += moveVector * Time.deltaTime;

        ySpeed -= gravity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //피격시 데미지를 줌.
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().ExecuteOnDamaged(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3f;

    Vector3 moveVector;

    float healthPoint;
    [SerializeField] float healthPointMax = 100;
    [SerializeField] HPIndicator indicator;

    private void Start()
    {
        SetHealthPoint(healthPointMax);
    }

    // Update is called once per frame
    void Update()
    {
        MoveByAxes();
    }

    public void SetHealthPoint(float health)
    {
        healthPoint = health;
        indicator.SetIndicator(healthPoint/healthPointMax);
    }

    public void ExecuteOnDamaged(float damage)
    {
        SetHealthPoint(healthPoint - damage);
        Debug.Log("¾Æ¾ß");
    }

    void MoveByRigidBody()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W))
        {
            moveVector = transform.up; //(0,1,0)
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveVector = -1 * transform.right; //(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector = -1 * transform.up; //(0,-1,0)
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVector = transform.right; //(1,0,0)
        }
        else
        {
            moveVector = Vector3.zero;
        }

        rb.AddForce(moveVector * moveSpeed * Time.deltaTime);
    }

    void MoveByTransform()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.up; //(0,1,0)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector += -1 * transform.up; //(0,-1,0)
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector += -1 * transform.right; //(-1,0,0)
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right; //(1,0,0)
        }

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }
    void MoveByAxes()
    {
        moveVector = Input.GetAxis("Horizontal") * transform.right;
        moveVector += Input.GetAxis("Vertical") * transform.up;
        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime;
    }
}

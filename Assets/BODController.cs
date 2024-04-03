using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BODController : MonoBehaviour
{
    private Rigidbody2D mRigid;
    private Animator mAnimator;
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        mRigid = this.GetComponent<Rigidbody2D>(); 
        mAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, 0);
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            direction = direction + new Vector2(0, 1);
            isWalking = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            direction = direction + new Vector2(-1, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = direction + new Vector2(0, -1);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = direction + new Vector2(1, 0);
            isWalking = true;
        }
        Move(direction, isWalking);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }

    private void Attack()
    {
        mAnimator.SetTrigger("Attack");
    }

    private void Move(Vector2 direction, bool isWalking)
    {
        if (isWalking)
        {
            print(direction);
            mRigid.velocity = speed * direction;
        } else
        {
            mRigid.velocity = new Vector2(0, 0);
        }

        if (direction.x != 0)
        {
            this.transform.localScale = new Vector3(-1 * direction.x, 1, 1);
        }
        
        mAnimator.SetBool("Walking", isWalking);
    }
}

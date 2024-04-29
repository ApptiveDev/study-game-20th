using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Move();
}

public abstract class Weapon : MonoBehaviour, IWeapon
{
    protected Vector3 moveVector;

    protected GameObject target;
    protected float moveSpeed = 5f;

    protected bool isInit = false;

    public void Init(GameObject targetObj)
    {
        target = targetObj;
        isInit = true;
    }

    public void Init()
    {
        isInit = true;
    }

    protected void Update()
    {
        if (isInit)
        {
            Move();
        }
    }

    public abstract void Move();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().OnDead();
            gameObject.SetActive(false);
        }
    }
}

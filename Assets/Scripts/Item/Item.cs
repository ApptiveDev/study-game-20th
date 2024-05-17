using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameManager gameManager;
    Transform pTransform;
    Vector3 moveVector;
    bool findedByPlayer = false;
    protected ObjectPoolController itemPoolController;
    protected bool isEaten = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        findedByPlayer = false;
        isEaten = false;
        pTransform = gameManager.getPlayer().GetComponent<Transform>();
        moveVector = new Vector3();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (findedByPlayer)
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            findedByPlayer = true;
        }
    }

    protected void Move()
    {
        float deltaX = pTransform.position.x - transform.position.x;
        float deltaY = pTransform.position.y - transform.position.y;

        if (deltaX < 0.5f & deltaY < 0.5f)
        {
            isEaten = true;
            itemPoolController.AddToPool(gameObject);
            gameObject.SetActive(false);
        }

        moveVector.Set(deltaX, deltaY, 0);
        moveVector.Normalize();
        transform.position += Time.deltaTime * moveVector * 5;


    }
}

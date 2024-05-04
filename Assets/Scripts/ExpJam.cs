using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpJam : MonoBehaviour
{
    GameManager gameManager;
    Transform pTransform;
    Vector3 moveVector;
    bool findedByPlayer = false;
    ExpBar playerExp;
    int expValue = 3;
    ExpJamPoolController mExpJamPoolController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        pTransform = gameManager.getPlayer().GetComponent<Transform>();
        moveVector = new Vector3();
        playerExp = gameManager.getExpBar();
        mExpJamPoolController = gameManager.getExpJamPoolController();
    }

    private void Move()
    {
        float deltaX = pTransform.position.x - transform.position.x;
        float deltaY = pTransform.position.y - transform.position.y;

        if (deltaX < 0.5f & deltaY < 0.5f)
        {
            AddExp();
            mExpJamPoolController.ReturnExpJam(gameObject);
            gameObject.SetActive(false);
        }
        
        moveVector.Set(deltaX, deltaY, 0);
        moveVector.Normalize();
        transform.position += Time.deltaTime * moveVector * 5;

        
    }

    void AddExp()
    {
        playerExp.AddExpBar(expValue);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            findedByPlayer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (findedByPlayer)
        {
            Move();
        }
    }
}

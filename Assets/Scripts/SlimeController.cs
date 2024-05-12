using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : Enemy
{
    Transform playerTransform;
    Rigidbody2D mRigid;


    // Start is called before the first frame update
    void Start()
    {
        objectPoolController = GameManager.Instance.getGameManager().GetComponent<SlimePoolController>();//GameObject.Find("GameManager").GetComponent<SlimePoolController>();
        playerTransform = GameManager.Instance.getPlayer().GetComponent<Transform>();//GameObject.Find("BOD").GetComponent<Transform>();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
        mExpJamPoolController = GameManager.Instance.getExpJamPoolController();
    }

    private void Move()
    {
        float deltaX = playerTransform.position.x - transform.position.x;
        float deltaY = playerTransform.position.y - transform.position.y;
        float a = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
        mRigid.velocity = new Vector2(deltaX / a, deltaY / a);
    }   

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

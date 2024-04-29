using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    private int hp = 1;
    private SlimePoolController mSlimePoolController;
    Transform playerTransform;
    private float speed = 1f;

    Rigidbody2D mRigid;

    public void Damaged()
    {
        hp -= 1;
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            mSlimePoolController.isDead(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Attack");
        if (collision.tag == "Player")
        {
            collision.GetComponent<BODController>().Damaged();
        }
    }

 

    

    // Start is called before the first frame update
    void Start()
    {
        mSlimePoolController = GameManager.Instance.getGameManager().GetComponent<SlimePoolController>();//GameObject.Find("GameManager").GetComponent<SlimePoolController>();
        playerTransform = GameManager.Instance.getPlayer().GetComponent<Transform>();//GameObject.Find("BOD").GetComponent<Transform>();
        mRigid = gameObject.GetComponent<Rigidbody2D>();
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

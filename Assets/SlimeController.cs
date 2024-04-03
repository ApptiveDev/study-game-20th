using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    private int hp = 1;
    public ObjectPoolController mObjectPoolController;

    public void Damaged()
    {
        hp -= 1;
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            mObjectPoolController.isDead(this.gameObject);
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
        mObjectPoolController = GameObject.Find("SlimeDispensor").GetComponent<ObjectPoolController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

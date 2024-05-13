using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Vector3 moveVector ;
    public int Health = 100;
    public static int Exp = 0;
    public static int MaxExp = Level * 5;
    public static int Level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTransform() ;
        if (Health < 1)
        {
            CharaterDead();
        }
    }

    void MoveTransform()
    {
        moveVector = Vector3.zero ;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.up ;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVector += -1 * transform.up ;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right ;   
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveVector += -1 * transform.right ;
        }

        transform.position += moveVector.normalized * moveSpeed * Time.deltaTime  ;
        
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy")) 
        {
                StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        while (true)
        {
            Health -= 10;
            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StopAllCoroutines();
        }
    }

    void CharaterDead()
    {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
    }

}

    
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

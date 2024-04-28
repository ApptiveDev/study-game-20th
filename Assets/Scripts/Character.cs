using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Vector3 moveVector ;
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTransform() ;
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
            moveVector += -1 * transform.up ; //transform은 up right밖에 안되나?
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
    
    void OnTriggerEnter(Collider other) //충돌 처리/근데 콜리드가 뭐임? 이거 어따 넣어야됨? 여기에 빼놔도 되나?
    {
        if (other.CompareTag("Enemy")) //Comparetag도 뭔지 모름FindGameObjectWithTag쓰면 왜안됨?
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int Damage) //피해처리
    {
        Health -= Damage;
    }
}

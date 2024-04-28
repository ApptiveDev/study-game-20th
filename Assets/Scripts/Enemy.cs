using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Character; 
    float ApproachSpeed = 1f; //접근 속도

    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemyTransform();
    }

    void GetPlayer()
    {
        Character = GameObject.FindGameObjectWithTag("Player"); //플레이어 태그를 가진 캐릭터 가져오기 근데 이거 뭔 코드인지 모름
    }
     void MoveEnemyTransform()
    {
        Vector3 direction = (Character.transform.position - transform.position).normalized;
        // 오브젝트를 캐릭터 쪽으로 이동
        transform.position += direction * ApproachSpeed * Time.deltaTime;
    }
}

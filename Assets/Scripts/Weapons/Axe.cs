using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour
{
    private float upSpeed = 20f; // 무기의 상승 속도
    private Vector3 moveDirection; // 무기의 이동 방향

    float Timescale = 0;
    int weaponLevel = 1; 

    private void Start()
    {
        
    }

    private void Update()
    {
        for(int i = 0; i < weaponLevel;  i++)
        {
            MoveAxe();
        }
        Timescale += 1f * Time.deltaTime;
    }

    void MoveAxe()
    {
            moveDirection = Vector3.up;
            transform.position += moveDirection * upSpeed * Time.deltaTime;

            if (Timescale > 5f) 
            {
                Destroy(gameObject);
                Timescale = 0;
            }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy")) 
        {
                Destroy(gameObject);
        }
    }

    public void LevelUp()
    {
        weaponLevel++;
    }
}

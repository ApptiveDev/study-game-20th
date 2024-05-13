
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Vector3 moveVector ;
    public Image hpBarImage;
    public Image expBarImage;
    public int Health = 100;
    public static int Exp = 0;
    public static int MaxExp = Level * 5;
    public static int Level = 1;
    private float expPercent;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        HpBar();
        ExpBar();
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

    private void HpBar() {
        float hpPercent = Health / 10f;
        hpBarImage.fillAmount = hpPercent;
    }

    private void ExpBar() {
        if (Level >= 8)
        {
            expPercent = 1;
        }
        else
        {
            expPercent = (float)Exp / (float)((Level+1)*5);
        }
        expBarImage.fillAmount = expPercent;
    }
}

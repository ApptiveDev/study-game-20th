using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{    
    private float CharacterHealthPoint = 10f;
    public static int Exp = 0;
    public static int Level = 0;
    [SerializeField]
    private Image hpBarImage;
    [SerializeField]
    private Image expBarImage;
    [SerializeField]
    private GameObject heart;
    [SerializeField]
    private GameObject expCoin;
    private float expPercent;
    

    void Start() {
        Instantiate(heart,new Vector3(-16.73f,8.36f,0),Quaternion.identity);
        Instantiate(expCoin,new Vector3(-16.73f,7.36f,0),Quaternion.identity);
        hpBarImage.transform.position = new Vector3(298,1012,0);
        expBarImage.transform.position = new Vector3(298,939,0);
    }

    void Update()
    {
        MoveAndflip();
        HpBar();
        ExpBar();
    }

    void MoveAndflip() 
    {
        Vector2 vec = new Vector2(0f,0f);

        if (Input.GetKey (KeyCode.A)) {
            transform.localScale = new Vector3(3.3849f,3.3849f,3.3849f);
            vec.x = -1f;
        }

        if (Input.GetKey (KeyCode.D)) {
            transform.localScale = new Vector3(-3.3849f,3.3849f,3.3849f);
            vec.x = 1f;
        }

        if (Input.GetKey (KeyCode.W)) {
            vec.y = 1f;
        }

        if (Input.GetKey (KeyCode.S)) {
            vec.y = -1f;
        }

        transform.Translate(vec.normalized * Time.deltaTime * 8f);

        if (transform.position.x < -16) {
            transform.position = new Vector3(-16,transform.position.y,0);
        }

        if (transform.position.x > 16) {
            transform.position = new Vector3(16,transform.position.y,0);
        }

        if (transform.position.y < -9.6) {
            transform.position = new Vector3(transform.position.x,-9.6f,0);
        }

        if (transform.position.y > 5.25f) {
            transform.position = new Vector3(transform.position.x,5.25f,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {   
            CharacterHealthPoint--;
            CharaterDead();
        }
    }

    public void LevelUp() {
        if ((Exp == (Level+1) * 5) & (Level < 4))
        {
            Time.timeScale = 0.03f;
            GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(960,540,0);
            Exp = 0;
        }
    }

    private void CharaterDead()
    {
        if (CharacterHealthPoint < 1)
        {
            HpBar();
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    private void HpBar() {
        float hpPercent = CharacterHealthPoint / 10f;
        hpBarImage.fillAmount = hpPercent;
    }

    private void ExpBar() {
        if (Level >= 4)
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

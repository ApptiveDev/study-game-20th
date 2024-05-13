using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Character : MonoBehaviour
{    
    private float CharacterHealthPoint = 10f;
    public float Speed = 1;
    public int Exp = 0;
    public int Level = 0;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Image expBarImage;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject expCoin;
    private float expPercent;
    RotatingWeapon RW;
    FireBomb FB;
    private Animator animator;
    public bool GameOver = false;
    public GameObject GameOverPanel;
    

    void Start() {
        animator = GetComponent<Animator>();
        Instantiate(heart,new Vector3(-30.85f,15.97f,0),Quaternion.identity);
        Instantiate(expCoin,new Vector3(-30.85f,13.82f,0),Quaternion.identity);
        hpBarImage.transform.position = new Vector3(298,1012,0);
        expBarImage.transform.position = new Vector3(298,939,0);
    }

    void Update()
    {
        Walk();
        RunAndflip();
        HpBar();
        ExpBar();
    }

    void Walk() {
        if (!GameOver)
        {
            animator.SetInteger("AnimState",0);
        }
        
    }

    void RunAndflip() 
    {
        if (!GameOver)
        {
            Vector2 vec = new Vector2(0f,0f);

            if (Input.GetKey (KeyCode.A)) {
                animator.SetInteger("AnimState",2);
                transform.localScale = new Vector3(3.3849f,3.3849f,3.3849f);
                vec.x = -1f;
            }

            if (Input.GetKey (KeyCode.D)) {
                animator.SetInteger("AnimState",2);
                transform.localScale = new Vector3(-3.3849f,3.3849f,3.3849f);
                vec.x = 1f;
            }

            if (Input.GetKey (KeyCode.W)) {
                animator.SetInteger("AnimState",2);
                vec.y = 1f;
            }

            if (Input.GetKey (KeyCode.S)) {
                animator.SetInteger("AnimState",2);
                vec.y = -1f;
            }

            transform.Translate(vec.normalized * Time.deltaTime * 8f * Speed);

            if (transform.position.x < -31.5f) {
                transform.position = new Vector3(-31.5f,transform.position.y,0);
            }

            if (transform.position.x > 31.5f) {
                transform.position = new Vector3(31.5f,transform.position.y,0);
            }

            if (transform.position.y < -18) {
                transform.position = new Vector3(transform.position.x,-18,0);
            }

            if (transform.position.y > 14) {
                transform.position = new Vector3(transform.position.x,14,0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyBall")
        {   
            CharacterHealthPoint--;
            if (CharacterHealthPoint < 1) {
                CharaterDead();
            }
        }

        if (other.tag == "Boss")
        {
            CharacterHealthPoint -= 2;
            if (CharacterHealthPoint < 1) {
                CharaterDead();
            }
        }
    }

    public void CheckLevelUp() {
        if (Exp == ((Level+1) * 5) && Level < 8)
        {
            Level++;
            RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
            Time.timeScale = 0f;
            if (RW.Level < 4 && FireBombSpawner.SpawnTime > 0.5f) 
            {
                Time.timeScale = 0f;
                GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(508.98f,540,0);
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(960,540,0);
                GameObject.FindGameObjectWithTag("Image3").transform.position = new Vector3(1411.02f,540,0);
            }
            else if (RW.Level >= 4)
            {
                Time.timeScale = 0f;
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(960,540,0);
                GameObject.FindGameObjectWithTag("Image3").transform.position = new Vector3(1411.02f,540,0);
            }
            else if (FireBombSpawner.SpawnTime <= 0.5f)
            {
                GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(508.98f,540,0);
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(960,540,0);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(1411.02f,540,0);
            }
            Exp = 0;
        }
    }

    private void CharaterDead()
    {
        HpBar();
        GameOver = true;
        animator.SetInteger("AnimState",4);
        Time.timeScale = 0.33f;
        GameOverPanel.SetActive(true);
    }

    private void HpBar() {
        float hpPercent = CharacterHealthPoint / 10f;
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

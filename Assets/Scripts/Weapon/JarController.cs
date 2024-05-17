using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarController : Weapon
{
    float gravity = 10;
    float y_deltaPosition = 10;
    float x_deltaPosition;
    Vector3 deltaPosition = new Vector3(0, 0, 0);
    Animator mAnimator;
    JarPoolController mJarPoolController;
    

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = gameObject.GetComponent<Animator>();
        mJarPoolController = GameManager.Instance.getPlayer().GetComponent<JarPoolController>();
        
    }

    public void InitJar()
    {
        gravity = 10;
        y_deltaPosition = 10;
        x_deltaPosition = Random.Range(-5, 5);
        numAttack = 0;
        StartCoroutine(autoBreakJar());
    }

    void Move()
    {
        float deltaTime = Time.deltaTime;
        deltaPosition.y = y_deltaPosition;
        y_deltaPosition -= gravity * deltaTime;
        deltaPosition.x = x_deltaPosition;
        transform.position += deltaTime * deltaPosition;
    }


    IEnumerator breakJar()
    {
        yield return new WaitForSeconds(0.5f);
        mJarPoolController.isDead(gameObject);
        gameObject.SetActive(false);
    }

    IEnumerator autoBreakJar()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(breakJar());
    }

    // Update is called once per frame
    void Update()
    {
        if (numAttack >= 1)
        {
            mAnimator.SetTrigger("breakJar");
            StartCoroutine(breakJar());
        }
        else
        {
            Move();
        }
    }
}

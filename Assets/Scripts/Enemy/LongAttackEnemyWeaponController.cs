using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackEnemyWeaponController : MonoBehaviour
{
    Vector3 deltaTransform;
    LongAttackEnemyWeaponPoolController mPoolController;
    int arrowSpeed = 5;
    private void Start()
    {
        deltaTransform = new Vector3();
        mPoolController = GameManager.Instance.getGameManager().GetComponent<LongAttackEnemyWeaponPoolController>();
    }

    IEnumerator Moving(Vector3 deltaTransform)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += deltaTransform * 0.01f * arrowSpeed;
        }
    }

    IEnumerator AutoBreak()
    {
        yield return new WaitForSeconds(10f);
        mPoolController.AddToPool(gameObject);
        gameObject.SetActive(false);
    }

    public void InitArrow(Vector3 targetPosition)
    { 
        deltaTransform = targetPosition - transform.position;
        deltaTransform.Normalize();
        StartCoroutine(Moving(deltaTransform));
        StartCoroutine(AutoBreak());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<BODController>().Damaged();
            mPoolController.AddToPool(gameObject);
            gameObject.SetActive(false);
        }
    }

}

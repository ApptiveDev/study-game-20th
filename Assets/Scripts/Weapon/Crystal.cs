using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] float damage = 2f;
    [SerializeField] float duration = 10f;
    [SerializeField] float tickTime = 1f;
    [SerializeField] float range = 5f;

    EnemySpawner spawner;
    List<Enemy> enemyList;

    List<Enemy> checkedEnemyList;

    float lifetime;
    private void Start()
    {
        enemyList = GameObject.FindObjectOfType<EnemySpawner>().enemyList;
        checkedEnemyList = new ();
        StartCoroutine(CheckDamage());
    }

    public IEnumerator CheckDamage()
    {
        lifetime = Time.time + duration;

        while(lifetime > Time.time)
        {
            yield return new WaitForSeconds(tickTime);

            foreach (Enemy enemy in enemyList)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) < range)
                {
                    checkedEnemyList.Add(enemy);
                }
            }

            foreach (Enemy enemy in checkedEnemyList)
            {
                enemy.ExecuteOnDamaged(damage);
            }
        }

        gameObject.SetActive(false);
    }
}

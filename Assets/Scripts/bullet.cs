using UnityEngine;

public class Bullet : PoolAble
{
    public float speed = 1f;
    private ObjectPoolManager poolManager;
    public string ObjectName;
    int weaponLevel = 1; 

    void Start()
    {
        SpawnBullets(weaponLevel);

    }
    void Update()
    {
        if (this.transform.position.x > 5)
        {
            ReleaseObject();
        }

        this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
    }

    void SpawnBullets(int weaponLevel)
    {
        for (int i = 0; i < weaponLevel; i++)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * i;

            GameObject bulletObj = poolManager.GetGo(ObjectName);
            bulletObj.transform.position = spawnPosition;

            Bullet bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetBulletDirection(Vector3.left); // 총알 이동 방향 설정
            }
        }
    }

    public void SetBulletDirection(Vector3 direction)
    {
        transform.right = direction; // 총알의 전방 방향 설정
    }

    public void LevelUp()
    {
        weaponLevel++;
    }
}
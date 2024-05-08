using UnityEngine;

public class Sanctuary : PoolAble
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    float Timescale = 0;
    int weaponLevel = 1; 

    void Start()
    {
        
    }
    
    private void Update()
    {
        CreateSanctuary();
        Timescale += 1f * Time.deltaTime;
        if (Timescale > 1.5f *  weaponLevel)
        {
            Destroy(gameObject);
            Timescale = 0;
        }
    }

   private void CreateSanctuary()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = playerPosition;
    }

    public void LevelUp()
    {
        weaponLevel++;
    }
}
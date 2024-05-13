using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    GameObject player = null;
    float Timescale = 0;
    int weaponLevel = 1; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        Timescale += 1f * Time.deltaTime;
        if (Timescale > 1.5f *  weaponLevel)
        {
            Destroy(gameObject);
            Timescale = 0;
        }
    }

    public void LevelUp()
    {
        weaponLevel++;
    }
}
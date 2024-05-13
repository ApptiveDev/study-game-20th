using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character character;

    private void Start()
    {
        Character chara = GameObject.Find("Character").GetComponent<Character>();
    }
}

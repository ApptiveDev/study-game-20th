using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    float gravity = 2f;
    float initForce = 4f;
    float xForceBound = 2f;
    float yForceBound = 5f;

    public override void Move()
    {
        moveVector = new Vector3(Random.Range(-xForceBound, xForceBound),initForce - gravity);
        transform.position += moveVector * Time.deltaTime;
        gravity += gravity;
        gravity = Mathf.Clamp(gravity, -yForceBound, yForceBound);
    }
}

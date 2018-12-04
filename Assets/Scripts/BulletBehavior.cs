using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour 
{
    public float speed;

	void Update () 
    {
        //will move the bullet
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
	}
}
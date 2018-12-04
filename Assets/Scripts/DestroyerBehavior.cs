using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBehavior : MonoBehaviour 
{
    private void OnCollisionEnter(Collision bullet)
    {
        Destroy(bullet.gameObject); // will destroy the bullet
    }
}

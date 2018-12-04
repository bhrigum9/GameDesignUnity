using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Text scoreDisplay;
    private long score = 0;

    void Start () 
    {
        transform.position = new Vector3(Input.mousePosition.x * speed, 0, -9);    	
	}
	
	void Update () 
    {
        //will move at the x axis of the mouse position
        transform.position = new Vector3(Input.mousePosition.x * speed-25, 0, -9);
	}

    private void OnCollisionEnter(Collision bullet)
    {
        //destroy the bullet
        Destroy(bullet.gameObject);
        score++; // add +1 to the score
        scoreDisplay.text = "Score: "+score;
    }
}

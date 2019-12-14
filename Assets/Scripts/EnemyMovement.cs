using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AIAnimation
{
    private float speed = 1.8f;
	// Use this for initialization
	void Start ()
    {
        Begin();
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (DroneLight.moreIntence)
        {
            GetComponentInChildren<CircleCollider2D>().radius = 5.4f;
        }
        else if (DroneLight.lessIntence)
        {
            GetComponentInChildren<CircleCollider2D>().radius = 0.6f;
        }
        else
        {
            GetComponentInChildren<CircleCollider2D>().radius = 1.8f;
        }

        if (this.canInteract)
        {
            transform.position = Vector2.MoveTowards(transform.position, this.target.position, speed * Time.deltaTime);
        }

        Animation();
    }
}

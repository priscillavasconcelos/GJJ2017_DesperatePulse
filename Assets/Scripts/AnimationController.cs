using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    MovementController movController;
    SpriteRenderer rend;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        movController = GetComponent<MovementController>();
        rend = GetComponent<SpriteRenderer>();
        //rend.flipX = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movController.hAxis > 0)
        {
            //rend.flipX = false;
            anim.SetInteger("Status", 0); 
        }
        else if(movController.hAxis < 0)
        {
            //rend.flipX = true;
            anim.SetInteger("Status", 0);
        }

        if (movController.vAxis > 0)
        {
            anim.SetInteger("Status", 1);
        }
        else if(movController.vAxis < 0)
        {
            anim.SetInteger("Status", 2);
        }
	}
}

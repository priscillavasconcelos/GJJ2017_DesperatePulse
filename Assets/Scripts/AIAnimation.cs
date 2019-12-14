using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : Interaction
{
    Animator anim;
    SpriteRenderer rend;

    protected Transform target;

    Vector3 lastFramePosition;

    // Use this for initialization
    protected void Begin ()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        lastFramePosition = transform.position;
    }

    // Update is called once per frame
    protected void Animation ()
    {
        Vector3 relativePoint = transform.InverseTransformPoint(target.position.x, target.position.y, 0);
        //print(Mathf.Abs(relativePoint.x) + "  ||  " + Mathf.Abs(relativePoint.y));
        if (Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            if (relativePoint.x > 0)
            {
                rend.flipX = false;
                if (transform.position != lastFramePosition)
                {
                    anim.SetInteger("Status", 0);
                }
                else
                {
                    anim.SetInteger("Status", 1);
                }

            }
            else //if (relativePoint.x < 0)
            {
                rend.flipX = true;
                if (transform.position != lastFramePosition)
                {
                    anim.SetInteger("Status", 0);
                }
                else
                {
                    anim.SetInteger("Status", 1);
                }
            }
        }
        else
        {
            if (relativePoint.y > 0)
            {
                if (transform.position != lastFramePosition)
                {
                    anim.SetInteger("Status", 2);
                }
                else
                {
                    anim.SetInteger("Status", 3);
                }
            }
            else //if (relativePoint.y < 0)
            {
                if (transform.position != lastFramePosition)
                {
                    anim.SetInteger("Status", 4);
                }
                else
                {
                    anim.SetInteger("Status", 5);
                }
            }
        }
        lastFramePosition = transform.position;
        
    }
}

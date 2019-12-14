using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLight : MonoBehaviour
{
    Animator anim;

    public static bool moreIntence, lessIntence;

    CircleCollider2D myColl;

    Light light;

    public Transform astronaut;
    // Use this for initialization
    void Start ()
    {
        myColl = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, astronaut.position);

        if (distance > 6.0f)
        {
            light.color = Color.red;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("MoreIntence", true);
            moreIntence = true;
            myColl.radius = 3.0f;
        }

        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("LessIntence", true);
            lessIntence = true;
            myColl.radius = 0.5f;
        }


        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.C))
        {
            anim.SetBool("LessIntence", false);
            lessIntence = false;
            myColl.radius = 2.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Totem" && other.gameObject.GetComponent<Totem>().mytotem != Totem.TotemStatus.FixedTotem)
        {
            astronaut.GetComponent<AstronautAI>().GoToTotem(other.transform);
        }

        if (other.tag == "Astronauta")
        {
            light.color = Color.white;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Astronauta")
        {
            light.color = Color.yellow;
        }
    }
}

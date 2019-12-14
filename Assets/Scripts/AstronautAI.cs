using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAI : AIAnimation
{
    public Transform myDrone, totemToGo;
    private float speed = 1.3f, min = 0.7f;
    private bool goToTotem = false;

    // Use this for initialization
    void Start ()
    {
        Begin();
        this.target = myDrone;
    }

    // Update is called once per frame
    void Update ()
    {
        Animation();
        if (!goToTotem)
        {
            float distance = Vector3.Distance(transform.position, myDrone.position);
            if (distance >= min)
            {
                transform.position = Vector2.MoveTowards(transform.position, myDrone.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (totemToGo.gameObject.GetComponent<Totem>().mytotem == Totem.TotemStatus.ToFix)
            {
                float distance = Vector3.Distance(transform.position, totemToGo.position);
                if (distance >= min)
                {
                    transform.position = Vector2.MoveTowards(transform.position, totemToGo.position, speed * Time.deltaTime);
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LightStuff")
        {
            if (totemToGo && totemToGo.gameObject.GetComponent<Totem>().mytotem == Totem.TotemStatus.FixedTotem)
            {
                this.target = myDrone;
                goToTotem = false;
            }
        }
    }

    public void GoToTotem(Transform totem)
    {
        totemToGo = totem;
        goToTotem = true;
        this.target = totem;
    }
}

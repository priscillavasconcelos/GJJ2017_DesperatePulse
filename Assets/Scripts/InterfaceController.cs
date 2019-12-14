using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour {

    Animator anim;
    public GameObject uiElement;

	// Use this for initialization
	void Start ()
    {
        anim = uiElement.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseEnter()
    {
        anim.SetBool("isHidden", false);
    }

    private void OnMouseExit()
    {
        anim.SetBool("isHidden", true);
    }


}

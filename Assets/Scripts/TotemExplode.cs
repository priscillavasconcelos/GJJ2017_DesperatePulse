﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotemExplode : Interaction
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.canInteract)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
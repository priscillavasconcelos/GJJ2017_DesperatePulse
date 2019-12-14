using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 position { get { return transform.position; } set { } }
    public bool isSelected { get; set; }

    // Use this for initialization
    void Start ()
    {
        position = transform.position;
        //Debug.Log(position);
	}

}

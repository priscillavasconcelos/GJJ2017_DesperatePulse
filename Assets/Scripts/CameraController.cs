using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform playerTranf;
    public float followDelay = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerFollow();
    }

    void PlayerFollow()
    {
        Vector3 transfPosition;
        transfPosition = new Vector3(playerTranf.position.x, playerTranf.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, transfPosition, followDelay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

    public AudioSource baseMusic;
    public AudioSource melody;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        baseMusic.volume = 1;
        melody.volume = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(SceneManager.GetActiveScene().name == "Menu")
        {
            melody.volume = 0;
        }
        else
        {
            melody.volume = 1;
        }
	}
}

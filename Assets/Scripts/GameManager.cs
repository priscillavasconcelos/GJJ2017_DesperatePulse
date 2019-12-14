using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentLife { get; private set; }
    public int totalLife;
    public LevelManager lm;

	// Use this for initialization
	void Start ()
    {
        currentLife = totalLife;
        lm = GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Totem.totemCount >= 3)
        {
            WinGame();
        }

        if(currentLife <= 0)
        {
            LooseGame();
        }
	}

    public void LooseLife(int damage)
    {
        currentLife -= damage;
    }

    public void GainLife(int healing)
    {
        currentLife += healing;
    }

    public void WinGame()
    {
        lm.CallVictoryScene();
    }

    public void LooseGame()
    {
        lm.CallGameOverScene();
    }
}

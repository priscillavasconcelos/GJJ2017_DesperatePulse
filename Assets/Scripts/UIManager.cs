using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider repairProgress;

    Totem totem;
	// Use this for initialization
	void Start ()
    {
        repairProgress.value = 0;
        repairProgress.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = GameManager.currentLife;
        if(totem != null)
        {
            repairProgress.value = totem.totemPercent;
            repairProgress.gameObject.SetActive(true);

            if (totem.totemPercent == 100)
            {
                totem = null;
            }
        }
        else
        {
            repairProgress.gameObject.SetActive(false);
        }
        

	}

    public void SetTotem(Totem totem)
    {
        this.totem = totem;
    }


}

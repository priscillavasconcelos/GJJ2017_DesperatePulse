using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Interaction
{
    public enum TotemStatus
    {
        ToFix,
        FixingTotem,
        FixedTotem
    };
    public static UIManager ui;

    public GameObject wave;

    public int totemPercent = 0;
    public static int totemCount = 0;
    Animator anim;

    //public bool fixedTotem = false, fixingTotem = false;

    public TotemStatus mytotem;

    void Start()
    {
        mytotem = TotemStatus.ToFix;
        if(ui == null)
        {
            ui = FindObjectOfType<UIManager>();
        }
        anim = GetComponent<Animator>();
    }

    private IEnumerator WaitAndInstantiate(float waitTime)
    {
        totemCount += 1;
        anim.SetInteger("Status", 1);
        for (int i = 0; i <= 2; i++)
        {
            GameObject newWave = Instantiate(wave, new Vector3(transform.position.x, transform.position.y, -0.2f), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(waitTime);
            Destroy(newWave, 5f);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Astronauta")
        {
            mytotem = TotemStatus.ToFix;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Astronauta")
        {
            StartCoroutine("FixTheTotem", 0.1f);
        }
    }

    private IEnumerator FixTheTotem(float waitTime)
    {
        mytotem = TotemStatus.FixingTotem;
        ui.SetTotem(this);

        while (totemPercent < 100 && mytotem == TotemStatus.FixingTotem)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.GetComponent<Totem>().totemPercent += 1;
            print(gameObject.GetComponent<Totem>().totemPercent);
        }

        if (totemPercent >= 100)
        {
            mytotem = TotemStatus.FixedTotem;
            StartCoroutine(WaitAndInstantiate(5.0f));
        }
    }

}

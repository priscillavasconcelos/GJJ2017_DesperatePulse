using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed = 1;
    SpriteRenderer rend;

    public float hAxis { get; set; }
    public float vAxis { get; set; }

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Movimentação do personagem
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        // Movimento com colisão na horizontal -------------------------------------------------------------------------------------

        // Flipar o boneco quando anda para a direita
        if (hAxis > 0)
        {
            rend.flipX = false;
            // Fazer o boneco não tremer quando encosta na parede
            if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z), 1 << LayerMask.NameToLayer("Walls")) == false)
            {
                transform.Translate(hAxis * speed * Time.deltaTime, 0, 0);
                Debug.DrawLine(transform.position, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z), Color.red);
            }
            else
            {
                Debug.Log("BATEU NA PAREDE DA DIREITA");
            }
        }
        // Flipar o boneco quando anda para a esquerda
        else if (hAxis < 0)
        { 
            rend.flipX = true;
            // Fazer o boneco não tremer quando encosta na parede
            if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z), 1 << LayerMask.NameToLayer("Walls")) == false)
            {
                transform.Translate(hAxis * speed * Time.deltaTime, 0, 0);
                Debug.DrawLine(transform.position, new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z), Color.red);
            }
            else
            {
                Debug.Log("BATEU NA PAREDE DA ESQUERDA");
            }
        }

        // Movimento com colisão na vertical -------------------------------------------------------------------------------------

        // Para cima
        if (vAxis > 0)
        {
            // Fazer o boneco não tremer quando encosta na parede
            if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), 1 << LayerMask.NameToLayer("Walls")) == false)
            {
                transform.Translate(0, vAxis * speed * Time.deltaTime, 0);
                Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Color.red);
            }
            else
            {
                Debug.Log("BATEU NA PAREDE DE CIMA");
            }    
        }
        // Para baixo
        else if (vAxis < 0)
        {
            // Fazer o boneco não tremer quando encosta na parede
            if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z), 1 << LayerMask.NameToLayer("Walls")) == false)
            {
                transform.Translate(0, vAxis * speed * Time.deltaTime, 0);
                Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z), Color.red);
            }
            else
            {
                Debug.Log("BATEU NA PAREDE DE BAIXO");
            }
        }
    }
}

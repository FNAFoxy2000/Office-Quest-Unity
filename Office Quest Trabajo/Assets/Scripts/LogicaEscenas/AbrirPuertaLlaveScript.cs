using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirPuertaLlaveScript : MonoBehaviour
{
    public GameObject Llave;
    public GameObject Puerta;

    private bool jugadorDentro = false;
    private bool tieneLlave;

    public Animator PuertaAnimator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            if (Llave.activeSelf)
            {               
                tieneLlave = false;
            }
            else
            {
                tieneLlave = true;
                
            }  
            if (tieneLlave == true)
            {
                PuertaAnimator.SetBool("isOpen", true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }
}

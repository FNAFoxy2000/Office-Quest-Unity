using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbirPuertaSalaNueva : MonoBehaviour
{
    private bool jugadorDentro = false;

    public Animator PuertaAnimator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            PuertaAnimator.SetBool("isOpen", true);
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

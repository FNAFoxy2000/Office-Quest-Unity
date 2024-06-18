using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbrirAscensor : MonoBehaviour
{
    private bool jugadorDentro = false;

    public Animator AscensorAnimator;

    public bool abierta = false;

    private int DCompletado = 0;

    public TMP_Text pulsaE;

    void Start()
    {
        DCompletado = PlayerPrefs.GetInt("2DCompletado");
        if (DCompletado == 1)
        {
            abierta = true;
        }

        if (abierta)
        {
            AscensorAnimator.SetBool("isOpen", true);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro && abierta == false)
        {
            AscensorAnimator.SetBool("isOpen", true);
            abierta = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && jugadorDentro && abierta == true)
        {
            AscensorAnimator.SetBool("isOpen", false);
            abierta = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
            pulsaE.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del collider es el jugador
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            pulsaE.gameObject.SetActive(false);
        }
    }

}

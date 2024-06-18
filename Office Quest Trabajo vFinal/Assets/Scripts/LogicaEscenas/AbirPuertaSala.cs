using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbirPuertaSala : MonoBehaviour
{
    private bool jugadorDentro = false;
    private bool puedeAbrir = false;

    public Animator PuertaAnimator;

    public TMP_Text pulsaE;

    void Start()
    {
        // Obtén el valor de PlayerPrefs "numJuegosCompletados"
        int numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");

        // Verifica si el número de juegos completados es igual a 2
        if (numJuegosCompletados == 2)
        {
            puedeAbrir = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro && puedeAbrir)
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

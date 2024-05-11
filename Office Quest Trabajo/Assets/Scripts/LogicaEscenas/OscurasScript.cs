using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class OscurasScript : MonoBehaviour
{
    // Define las luces que deseas controlar
    // inicializar luces
    public Light[] lucesPorApagar;
    public Light[] lucesPorEncender;

    public Animator interruptorAnimator;
    public Animator aireAnimator;


    private bool jugadorDentro = false;

    public AudioClip sonidoApagon, sonidoActivacion;

    void Start()
    {
        // Obtén el valor de PlayerPrefs "numJuegosCompletados"
        int numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");

        // Verifica si el número de juegos completados es igual a 2
        if (numJuegosCompletados == 2)
        {
            Debug.Log("OSCURAS !!!");
            CambiarEstadoLuces();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            // Activar interruptor y luces
            interruptorAnimator.SetBool("isActive", true);
            aireAnimator.SetBool("isActive", true);

            RestaurarEstadoLuces();
            AudioSource.PlayClipAtPoint(sonidoActivacion, transform.position);
        }
    }

    private void CambiarEstadoLuces()
    {
        foreach (Light luz in lucesPorApagar)
        {
            luz.enabled = false; 
        }
        foreach (Light luz in lucesPorEncender)
        {
            luz.enabled = true;
        }
    }
    private void RestaurarEstadoLuces()
    {
        foreach (Light luz in lucesPorApagar)
        {
            luz.enabled = true; // Activa todas las luces
        }
        foreach (Light luz in lucesPorEncender)
        {
            luz.enabled = false; // Activa todas las luces
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirPuertaLlaveScript : MonoBehaviour
{
    public GameObject Llave;
    public GameObject Puerta;

    private bool jugadorDentro = false;
    private bool tieneLlave;

    public Animator PuertaAnimator;

    public TMP_Text pulsaE;
    public TMP_Text needKey;

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
            else
            {
                needKey.gameObject.SetActive(true);
                StartCoroutine(DesactivarMensaje(3f));
            }
        }
    }
    IEnumerator DesactivarMensaje(float delay)
    {
        yield return new WaitForSeconds(delay);
        needKey.gameObject.SetActive(false);
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

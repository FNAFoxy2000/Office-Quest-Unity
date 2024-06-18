using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CodigoSecreto : MonoBehaviour
{
    // Start is called before the first frame update
    public Light pointLight;
    public TMP_Text miTexto3D;
    int digito2;
    public CapsuleCollider CapsuleAhorcado;
     private bool jugadorDentro = false;
    void Start()
{
    // Verifica si el jugador está dentro de la cápsula y ha presionado la tecla "E"
    if (jugadorDentro && Input.GetKeyDown(KeyCode.E))
    {
        Cursor.lockState = CursorLockMode.None;
        digito2 = PlayerPrefs.GetInt("Digito2");
        pointLight.enabled = false;

        // Guarda el valor de digito2 en PlayerPrefs
        PlayerPrefs.SetInt("Digito2", digito2);
        PlayerPrefs.Save(); // Guarda los cambios
    }
}

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }

}

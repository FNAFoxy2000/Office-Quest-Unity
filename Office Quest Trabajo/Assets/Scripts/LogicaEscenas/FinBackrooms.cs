using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinBackrooms : MonoBehaviour
{
    private bool jugadorDentro = false;
    int muñecos = 0;

    public Image blackScreen;

    public int fadeDuration = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            muñecos = PlayerPrefs.GetInt("MuñecosObtenidos");
            if(muñecos >= 5)
            {
                // Esperar 5 segundos, Fundido en negro, Cargar Escena Fin
                Debug.Log("JUEGO SUPERADO");
                StartCoroutine(GameOverSequence());
            }

            
        }
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(2); // Esperar 2 segundos

        // Fundido en negro
        float elapsedTime = 0;
        Color color = blackScreen.color;
        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            blackScreen.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la pantalla esté completamente negra
        color.a = 1;
        blackScreen.color = color;

        // Cargar la escena "Fin"
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("EscenaFinal");
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

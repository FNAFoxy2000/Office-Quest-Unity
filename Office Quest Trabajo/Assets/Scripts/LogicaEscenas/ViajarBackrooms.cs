using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViajarBackrooms : MonoBehaviour
{
    bool jugadorDentro = false;

    public Image blackScreen;

    public int fadeDuration = 5;

    public AudioSource ascensorCayendo;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro)
        {
            StartCoroutine(viajarBackrooms());
        }
    }

    IEnumerator viajarBackrooms()
    {


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
        //yield return new WaitForSeconds(2); // Esperar 2 segundos
        // Sonido de ascensor cayendo
        ascensorCayendo.Play();
        yield return new WaitForSeconds(5); // Esperar 2 segundos
        // Cargar la escena "Fin"
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Backrooms");
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

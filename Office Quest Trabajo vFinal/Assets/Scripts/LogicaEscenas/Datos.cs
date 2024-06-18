using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Datos : MonoBehaviour
{
    public Camera camaraPrincipal; // Referencia a la cámara principal
    public Camera camaraSecundaria; // Referencia a la otra cámara
    public Canvas canvas; // Referencia al canvas que deseas activar

    int numJuegosCompletados;
    int tiempoRestante;
    int mostrarDigito1;
    int mostrarDigito2;
    int mostrarDigito3;

    public GameObject jugador;

    public Light pointLight;
    public TMP_Text digito1String;
    public TMP_Text digito2String;
    public TMP_Text digito3String;

    int digito1;
    int digito2;
    int digito3;

    public GameObject colliderAhorcado;
    public GameObject colliderAdivinaNum;
    public GameObject colliderPreguntas;
    public GameObject colliderMinijuego;


    void Start()
    {
        camaraPrincipal.enabled = true;

        // Activar la otra cámara
        camaraSecundaria.enabled = false;

        // Activar el canvas
        canvas.gameObject.SetActive(false);
        Debug.Log("CARGANDO datos...");
        numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");
        tiempoRestante = PlayerPrefs.GetInt("TiempoRestante");

        // DIGITOS
        mostrarDigito1 = PlayerPrefs.GetInt("mostrarDigito1");
        mostrarDigito2 = PlayerPrefs.GetInt("mostrarDigito2");
        mostrarDigito3 = PlayerPrefs.GetInt("mostrarDigito3");

        digito1 = PlayerPrefs.GetInt("Digito1");
        digito2 = PlayerPrefs.GetInt("Digito2");
        digito3 = PlayerPrefs.GetInt("Digito3");


        if (mostrarDigito1 == 1)
        {
            digito1String.text = digito1.ToString();
            colliderAhorcado.gameObject.SetActive(false);
        }
        if (mostrarDigito2 == 1)
        {
            digito2String.text = digito2.ToString();
            colliderAdivinaNum.gameObject.SetActive(false);
        }
        if (mostrarDigito3 == 1)
        {
            digito3String.text = digito3.ToString();
            colliderPreguntas.gameObject.SetActive(false);
        }
        
        int minijuegoCompletado = PlayerPrefs.GetInt("2DCompletado");
        if (minijuegoCompletado == 1)
        {
            colliderMinijuego.gameObject.SetActive(false);
        }

        // POSICION
        float playerX = PlayerPrefs.GetFloat("PlayerX");
        float playerY = PlayerPrefs.GetFloat("PlayerY");
        float playerZ = PlayerPrefs.GetFloat("PlayerZ");
        Vector3 posicionActual = jugador.transform.position;
        float posY = posicionActual.y;
        if (posY < 0.0f) posY = 0.5f;
        jugador.transform.position = new Vector3(playerX, posY, playerZ);

        Debug.Log("Juegos completados: " + numJuegosCompletados + "\n" +
            "Tiempo restante: " + tiempoRestante);
    }

    // Update is called once per frame
    void Update()
    {
        // Guardar posicion jugador
        Vector3 posicionActual = jugador.transform.position;
        PlayerPrefs.SetFloat("PlayerX", posicionActual.x);
        PlayerPrefs.SetFloat("PlayerY", posicionActual.y);
        PlayerPrefs.SetFloat("PlayerZ", posicionActual.z);
        PlayerPrefs.Save();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Introduccion : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_Text startGame;
    public TMP_Text introGame;
    public TMP_Text introGame2;
    public UnityEngine.UI.Button confirm;
    void Start()
    {
        // Ocultar introGame y confirm
        introGame.gameObject.SetActive(false);
        introGame2.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);
        userName.gameObject.SetActive(false);

        // Mostrar startGame y establecer su texto
        startGame.gameObject.SetActive(true);

        confirm.onClick.AddListener(() => EmpezarJuego());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            introGame.gameObject.SetActive(true);
            userName.gameObject.SetActive(true);
            confirm.gameObject.SetActive(true);
            startGame.gameObject.SetActive(false);

        }
    }

    public void EmpezarJuego()
    {
        introGame2.gameObject.SetActive(true);
        Debug.Log("El juego ha empezado!");
        
        startGame.gameObject.SetActive(false);
        // Guardar el nombre introducido en PlayerPrefs
        PlayerPrefs.SetString("UserName", userName.text);

        if (!string.IsNullOrEmpty(userName.text))
        {
            confirm.gameObject.SetActive(false);
            Invoke("ChangeScene", 5f);
        }
        else
        {
            // Mostrar un mensaje de error porque el nombre de usuario está vacío
            Debug.Log("Por favor, introduce un nombre de usuario antes de continuar.");
        }


    }
    void ChangeScene()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }
}

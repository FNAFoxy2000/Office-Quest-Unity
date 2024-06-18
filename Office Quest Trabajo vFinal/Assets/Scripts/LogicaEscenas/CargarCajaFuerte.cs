using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class CargarCajaFuerte : MonoBehaviour
{
    public Camera camaraPrincipal; // Referencia a la cámara principal
    public Camera camaraSecundaria; // Referencia a la otra cámara
    public Canvas canvas; // Referencia al canvas que deseas activar

    private bool jugadorDentro = false;
    public Button button1, button2, button3, button4, button5, button6, button7, button8, button9, button0, buttonCancelar, buttonAceptar, buttonLlave;
    int digito1, digito2, digito3;
    List<int> numeros = new List<int>();
    int limiteNumeros = 3;

    public Animator cajaFuerteAnimator;

    public GameObject Llave;

    private bool isCamCaja = false;

    public TMP_Text pulsaE;

    void Start () {
        button1.onClick.AddListener(() => AñadirDigito(1));
        button2.onClick.AddListener(() => AñadirDigito(2));
        button3.onClick.AddListener(() => AñadirDigito(3));
        button4.onClick.AddListener(() => AñadirDigito(4));
        button5.onClick.AddListener(() => AñadirDigito(5));
        button6.onClick.AddListener(() => AñadirDigito(6));
        button7.onClick.AddListener(() => AñadirDigito(7));
        button8.onClick.AddListener(() => AñadirDigito(8));
        button9.onClick.AddListener(() => AñadirDigito(9));
        button0.onClick.AddListener(() => AñadirDigito(0));
        buttonCancelar.onClick.AddListener(() => BorrarDigitos());
        buttonAceptar.onClick.AddListener(() => ComprobarDigitos());
        buttonLlave.onClick.AddListener(() => CogerLlave());
        buttonLlave.enabled = false;

        digito1 = PlayerPrefs.GetInt("Digito1");
        digito2 = PlayerPrefs.GetInt("Digito2");
        digito3 = PlayerPrefs.GetInt("Digito3");

        Debug.Log("CODIGO: " + digito1 + "" + digito2 + "" + digito3);
    }

    public void AñadirDigito(int digito)
    {
        if (numeros.Count < limiteNumeros)
        {
            numeros.Add(digito);
        }
    }
    public void BorrarDigitos()
    {
        numeros.Clear();
    }
    public void ComprobarDigitos()
    {
        if ((numeros.Contains(digito1) && numeros.Contains(digito2) && numeros.Contains(digito3)) &&
    numeros.Count == 3)
        {
            // Abrir caja fuerte
            buttonLlave.enabled = true;
            cajaFuerteAnimator.SetBool("isOpen", true);
        }
        else
        {
            Debug.Log("Combinación incorrecta");
        }
    }

    public void CogerLlave()
    {
        if (Llave != null)
        {
            Llave.SetActive(false);
        }
    }


    void Update()
    {
        // Si el jugador presiona la tecla "E" y está dentro del área
        if (Input.GetKeyDown(KeyCode.E) && jugadorDentro && !isCamCaja)
        {
            Cursor.lockState = CursorLockMode.None;
            isCamCaja = true;
            // Desactivar la cámara principal
            camaraPrincipal.enabled = false;

            // Activar la otra cámara
            camaraSecundaria.enabled = true;

            // Activar el canvas
            canvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isCamCaja)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isCamCaja = false;
            // Desactivar la cámara principal
            camaraPrincipal.enabled = true;

            // Activar la otra cámara
            camaraSecundaria.enabled = false;

            // Activar el canvas
            canvas.gameObject.SetActive(false);
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
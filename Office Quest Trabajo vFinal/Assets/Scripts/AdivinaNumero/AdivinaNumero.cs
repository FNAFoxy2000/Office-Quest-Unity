using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AdivinaNumero : MonoBehaviour
{
    public TMP_InputField inputField;
    public Contador contadorScript;
    public TMP_Text wordToGuessText;
    public TMP_Text fallos;
    public TMP_Text NumerosFallados;
    public Button button;
    public Button button2;
    public TMP_Text contadorResta;
    private int numeroAdivinar;
    private int intentos = 0;
    private int numFallos = 0;
    private int numJuegosCompletados;

    private List<int> numerosFallados = new List<int>();

    void Start()
    {
        // Inicializar el juego
        contadorResta.gameObject.SetActive(false);
        IniciarJuego();
        button.onClick.AddListener(ComprobarNumero);
        button2.onClick.AddListener(ComprobarNumero2);
        button2.gameObject.SetActive(false);

    }

    void IniciarJuego()
    {
        // Generar un número aleatorio entre 1 y 50
        numeroAdivinar = Random.Range(1, 51); // Cambiado a 51 para incluir el 50
        // Reiniciar el contador de intentos y la lista de números fallados
        intentos = 0;
        numFallos = 0;

        numerosFallados.Clear();
        // Actualizar el texto para que el jugador sepa que debe adivinar un número
        wordToGuessText.text = "Serás capaz de adivinar el número que estoy pensando entre 1 y 50...";
        // Limpiar los campos de texto
        inputField.text = "";
        fallos.text = "Intentos: 0";
        NumerosFallados.text = "Números fallados: ";
    }
    void IniciarJuego2()
    {
        // Generar un número aleatorio entre 1 y 50
        numeroAdivinar = Random.Range(1, 67); // Cambiado a 51 para incluir el 50
        // Reiniciar el contador de intentos y la lista de números fallados
        intentos = 0;
        numerosFallados.Clear();
        // Actualizar el texto para que el jugador sepa que debe adivinar un número
        wordToGuessText.text = "Serás capaz de adivinar el número que estoy pensando entre 1 y 66...";
        // Limpiar los campos de texto
        inputField.text = "";
        fallos.text = "Intentos: 0";
        NumerosFallados.text = "Números fallados: ";
    }

    public void ComprobarNumero()
    {
        Debug.Log("Comprobando número");
        // Obtener el número ingresado por el jugador desde el campo de entrada
        int numeroIngresado;
        if (int.TryParse(inputField.text, out numeroIngresado))
        {
            // Incrementar el contador de intentos
            intentos++;
            numFallos++;

            // Verificar si el número ingresado es igual al número a adivinar
            if (numeroIngresado == numeroAdivinar)
            {
                wordToGuessText.text = "¡Felicidades! Has adivinado el número " + numeroAdivinar + " en " + intentos + " intentos.";

                IniciarJuego2();
                button2.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
            }
            else
            {
                // Actualizar el texto para indicar si el número es mayor o menor
                wordToGuessText.text = (numeroIngresado < numeroAdivinar) ? "El número que estoy pensando es mayor." : "El número que estoy pensando es menor.";

                // Agregar el número fallado a la lista
                numerosFallados.Add(numeroIngresado);
                // Actualizar el texto de los números fallados
                NumerosFallados.text = "Números fallados: " + string.Join(", ", numerosFallados);
                // Actualizar el texto de los intentos
                fallos.text = "Intentos: " + intentos;
                if (numFallos == 5)
                {
                    contadorResta.gameObject.SetActive(true);
                    StartCoroutine(HideContadorResta());
                    contadorScript.JuegoPerdido(5);
                    numFallos = 0;

                }
            }
        }
        else
        {
            // Mensaje de error si el jugador no ingresa un número válido
            wordToGuessText.text = "Por favor, ingresa un número válido entre 1 y 100.";
        }
    }
    IEnumerator HideContadorResta()
    {
        // Espera 1 segundo
        yield return new WaitForSeconds(1f);

        // Desactiva el contador
        contadorResta.gameObject.SetActive(false);
    }
    public void ComprobarNumero2()
    {
        Debug.Log("Comprobando número");
        // Obtener el número ingresado por el jugador desde el campo de entrada
        int numeroIngresado;
        if (int.TryParse(inputField.text, out numeroIngresado))
        {
            // Incrementar el contador de intentos
            intentos++;

            // Verificar si el número ingresado es igual al número a adivinar
            if (numeroIngresado == numeroAdivinar)
            {
                wordToGuessText.text = "¡Felicidades! Has adivinado el número " + numeroAdivinar + " en " + intentos + " intentos.";
                // Cambiar a la escena principal
                numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");
                numJuegosCompletados = numJuegosCompletados + 1;
                PlayerPrefs.SetInt("JuegosCompletados", numJuegosCompletados);
                PlayerPrefs.SetInt("mostrarDigito2", 1);
                SceneManager.LoadScene("EscenaPrincipal");
            }
            else
            {
                // Actualizar el texto para indicar si el número es mayor o menor
                wordToGuessText.text = (numeroIngresado < numeroAdivinar) ? "El número que estoy pensando es mayor." : "El número que estoy pensando es menor.";

                // Agregar el número fallado a la lista
                numerosFallados.Add(numeroIngresado);
                // Actualizar el texto de los números fallados
                NumerosFallados.text = "Números fallados: " + string.Join(", ", numerosFallados);
                // Actualizar el texto de los intentos
                fallos.text = "Intentos: " + intentos;
                if (intentos == 5)
                {
                    contadorResta.gameObject.SetActive(true);
                    StartCoroutine(HideContadorResta());
                    contadorScript.JuegoPerdido(5);

                }
            }
        }
        else
        {
            // Mensaje de error si el jugador no ingresa un número válido
            wordToGuessText.text = "Por favor, ingresa un número válido entre 1 y 100.";
        }
    }


    // Método para establecer la posición del jugador en el inicio de la escena
    void Awake()
    {
        contadorScript = FindObjectOfType<Contador>();
        // Obtener la posición de la cápsula en la escena principal
        GameObject capsule = GameObject.Find("Capsule AdivinaNumero");
        if (capsule != null)
        {
            transform.position = capsule.transform.position;
        }
    }
}

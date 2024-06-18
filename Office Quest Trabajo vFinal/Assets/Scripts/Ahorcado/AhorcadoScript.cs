using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class AhorcadoScript : MonoBehaviour
{
    public Contador contadorScript;
    public TMP_InputField inputField;
    public TMP_Text wordToGuessText;
    public TMP_Text pista;
    public TMP_Text hangmanProgressText; // Texto para mostrar el progreso del ahorcado
    public TMP_Text letrasFalladas; // Texto para mostrar las letras falladas
    public Button button; // Botón para comprobar la letra
    public Button button2; // Botón para comprobar la letra
    public Button button3; // Botón para comprobar la letra
    public TMP_Text contadorResta;

    public TMP_Text hangmanArt; // Texto para mostrar el dibujo del ahorcado

    private List<string> animals = new List<string> { "CONEJO", "PERRO", "OSO", "GATO" }; // Lista de palabras a adivinar
    private List<string> office = new List<string> { "MESA", "ORDENADOR", "ESCRITORIO", "SILLA" };
    private List<string> kill = new List<string> { "AHORCADO", "DISPARADO", "APUÑALADO", "TORTURADO" };
    private string wordToGuess; // Palabra a adivinar
    private string currentGuess = ""; // Suponiendo que la palabra a adivinar se mostrará con guiones bajos para las letras no adivinadas
    private List<char> incorrectLetters = new List<char>(); // Lista de letras falladas
    private int wrongGuessCount = 0; // Contador de fallos
    int numJuegosCompletados;
void Awake()
{
    contadorScript = FindObjectOfType<Contador>();
}
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        InitializeGameAnimals();
        contadorResta.gameObject.SetActive(false);
        // Asegurarse de que el botón tenga asignada la función CheckLetter al hacer clic
        button.onClick.AddListener(CheckLetterAnimals);
        button2.onClick.AddListener(CheckLetterOffice);
        button3.onClick.AddListener(CheckLetterKill);
        
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);

        numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");
    }

    void InitializeGameAnimals()
    {
        // Seleccionar una palabra aleatoria de la lista
        int randomIndex = Random.Range(0, animals.Count);
        wordToGuess = animals[randomIndex];

        // Inicializar el texto de la palabra a adivinar con guiones bajos
        currentGuess = "";
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            currentGuess += "_ ";
        }
        wordToGuessText.text = currentGuess;

        // Limpiar el texto de letras falladas
        letrasFalladas.text = "";
        pista.text="La palabra a adivinar es un animal";
        // Limpiar la lista de letras falladas
        incorrectLetters.Clear();

        // Limpiar el dibujo del ahorcado
        hangmanArt.text = "";

        // Reiniciar el contador de fallos
        wrongGuessCount = 0;
        UpdateHangmanProgress();
    }
    void InitializeGameOffice()
    {
        // Seleccionar una palabra aleatoria de la lista
        int randomIndex = Random.Range(0, office.Count);
        wordToGuess = office[randomIndex];

        // Inicializar el texto de la palabra a adivinar con guiones bajos
        currentGuess = "";
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            currentGuess += "_ ";
        }
        wordToGuessText.text = currentGuess;

        // Limpiar el texto de letras falladas
        letrasFalladas.text = "";
        pista.text="La palabra a adivinar ahora es un objeto de oficina";
        // Limpiar la lista de letras falladas
        incorrectLetters.Clear();

        // Limpiar el dibujo del ahorcado
        hangmanArt.text = "";

        // Reiniciar el contador de fallos
        wrongGuessCount = 0;
        UpdateHangmanProgress();
    }
    void InitializeGameKill()
    {
        // Seleccionar una palabra aleatoria de la lista
        int randomIndex = Random.Range(0, kill.Count);
        wordToGuess = kill[randomIndex];

        // Inicializar el texto de la palabra a adivinar con guiones bajos
        currentGuess = "";
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            currentGuess += "_ ";
        }
        wordToGuessText.text = currentGuess;

        // Limpiar el texto de letras falladas
        letrasFalladas.text = "";
        pista.text="Crees que esto se ha acabado ahora tienes que adivinar tu tipo de muerte";
        // Limpiar la lista de letras falladas
        incorrectLetters.Clear();

        // Limpiar el dibujo del ahorcado
        hangmanArt.text = "";

        // Reiniciar el contador de fallos
        wrongGuessCount = 0;
        UpdateHangmanProgress();
    }



    public void CheckLetterAnimals()
    {
        string letter = inputField.text.ToUpper(); // Convertir la letra introducida a mayúsculas

        if (letter.Length == 1)
        {
            bool letterFound = false;

            // Comprobar si la letra introducida está en la palabra a adivinar
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter[0])
                {
                    // La letra está en la palabra a adivinar
                    currentGuess = currentGuess.Substring(0, i * 2) + letter + currentGuess.Substring((i * 2) + 1);
                    letterFound = true;
                }
            }

            if (!letterFound)
            {
                // La letra no está en la palabra a adivinar
                // Agregar la letra a la lista de letras falladas
                incorrectLetters.Add(letter[0]);
                // Actualizar el texto de letras falladas
                letrasFalladas.text = string.Join(" ", incorrectLetters);

                // Incrementar el contador de fallos
                wrongGuessCount++;
                UpdateHangmanProgress();
            }

            // Actualizar el texto de la palabra a adivinar
            wordToGuessText.text = currentGuess;

            // Verificar si se ha adivinado la palabra
            if (!currentGuess.Contains("_"))
            {
                PlayerPrefs.SetInt("mostrarDigito1", 1);
                // Cambiar a la escena principal
                InitializeGameOffice();
                button.gameObject.SetActive(false);
                button2.gameObject.SetActive(true);
                button3.gameObject.SetActive(false);
            }
        }

        // Limpiar el campo de entrada
        inputField.text = "";
    }
    public void CheckLetterOffice()
    {
        string letter = inputField.text.ToUpper(); // Convertir la letra introducida a mayúsculas

        if (letter.Length == 1)
        {
            bool letterFound = false;

            // Comprobar si la letra introducida está en la palabra a adivinar
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter[0])
                {
                    // La letra está en la palabra a adivinar
                    currentGuess = currentGuess.Substring(0, i * 2) + letter + currentGuess.Substring((i * 2) + 1);
                    letterFound = true;
                }
            }

            if (!letterFound)
            {
                // La letra no está en la palabra a adivinar
                // Agregar la letra a la lista de letras falladas
                incorrectLetters.Add(letter[0]);
                // Actualizar el texto de letras falladas
                letrasFalladas.text = string.Join(" ", incorrectLetters);

                // Incrementar el contador de fallos
                wrongGuessCount++;
                UpdateHangmanProgress();
            }

            // Actualizar el texto de la palabra a adivinar
            wordToGuessText.text = currentGuess;

            // Verificar si se ha adivinado la palabra
            if (!currentGuess.Contains("_"))
            {
                PlayerPrefs.SetInt("mostrarDigito1", 1);
                // Cambiar a la escena principal
                InitializeGameKill();
                button.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(true);
            }
        }

        // Limpiar el campo de entrada
        inputField.text = "";
    }
public void CheckLetterKill()
    {
        string letter = inputField.text.ToUpper(); // Convertir la letra introducida a mayúsculas

        if (letter.Length == 1)
        {
            bool letterFound = false;

            // Comprobar si la letra introducida está en la palabra a adivinar
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter[0])
                {
                    // La letra está en la palabra a adivinar
                    currentGuess = currentGuess.Substring(0, i * 2) + letter + currentGuess.Substring((i * 2) + 1);
                    letterFound = true;
                }
            }

            if (!letterFound)
            {
                // La letra no está en la palabra a adivinar
                // Agregar la letra a la lista de letras falladas
                incorrectLetters.Add(letter[0]);
                // Actualizar el texto de letras falladas
                letrasFalladas.text = string.Join(" ", incorrectLetters);

                // Incrementar el contador de fallos
                wrongGuessCount++;
                UpdateHangmanProgress();
            }

            // Actualizar el texto de la palabra a adivinar
            wordToGuessText.text = currentGuess;

            // Verificar si se ha adivinado la palabra
            if (!currentGuess.Contains("_"))
            {
                PlayerPrefs.SetInt("mostrarDigito1", 1);
                
                numJuegosCompletados = numJuegosCompletados + 1;
                PlayerPrefs.SetInt("JuegosCompletados", numJuegosCompletados);
                // Cambiar a la escena principal
                SceneManager.LoadScene("EscenaPrincipal");
            }
        }

        // Limpiar el campo de entrada
        inputField.text = "";
    }
 IEnumerator HideContadorResta()
    {
        // Espera 1 segundo
        yield return new WaitForSeconds(1f);

        // Desactiva el contador
        contadorResta.gameObject.SetActive(false);
    }
    void UpdateHangmanProgress()
    {
        // Actualizar el dibujo del ahorcado basado en el contador de fallos
        switch (wrongGuessCount)
        {
            case 1:
                hangmanArt.text = "   +---+\n   |      |\n          |\n          |\n          |\n          |\n          |";
                break;
            case 2:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n          |\n          |\n          |\n          |";
                break;
            case 3:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n   |      |\n          |\n          |\n          |";
                break;
            case 4:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n  /|      |\n          |\n          |\n          |";
                break;
            case 5:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n  /|\\     |\n          |\n          |\n          |";
                break;
            case 6:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n  /|\\     |\n  /       |\n          |\n          |";
                break;
            case 7:
                hangmanArt.text = "   +---+\n   |      |\n  O     |\n  /|\\     |\n  / \\     |\n          |\n          |";
                // Reiniciar la escena
                   // Activa el contador y espera 1 segundo antes de desactivarlo
                contadorResta.gameObject.SetActive(true);
                StartCoroutine(HideContadorResta());
                contadorScript.JuegoPerdido(5);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);

				break;
            default:
                break;
        }
    }
}

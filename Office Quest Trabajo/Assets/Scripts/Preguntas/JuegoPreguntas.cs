using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;   

public class JuegoPreguntas : MonoBehaviour
{
    public Contador contadorScript;
    public TMP_Text contadorResta;
    public TMP_Text questionText;
    public Button[] answerButtons;
    private preguntados[] cultura;
    
    private int currentQuestionIndex;
    private int preguntasAcertadas; // Contador de preguntas acertadas
    public string siguienteEscena; // Nombre de la escena a la que cambiar
    private int numJuegosCompletados;
    void Awake()
    {
        contadorScript = FindObjectOfType<Contador>();
    }

    void Start()
    {
        contadorResta.gameObject.SetActive(false);
        cultura = new preguntados[]
        {
            new preguntados("¿Cuál es la capital de Francia?", new string[]{"Londres", "París", "Madrid", "Roma"}, new string[]{"París"}),
            new preguntados("¿En qué año llegó el hombre a la luna?", new string[]{"1969", "1975", "1980", "1950"}, new string[]{"1969"}),
            new preguntados("¿Quién pintó la Mona Lisa?", new string[]{"Pablo Picasso", "Leonardo da Vinci", "Vincent van Gogh", "Michelangelo"}, new string[]{"Leonardo da Vinci"}),
            new preguntados("¿Qué planeta es conocido como el planeta rojo?", new string[]{"Venus", "Júpiter", "Marte", "Saturno"}, new string[]{"Marte"}),
            new preguntados("¿Cuál es el río más largo del mundo?", new string[]{"Nilo", "Amazonas", "Yangtsé", "Misisipi"}, new string[]{"Amazonas"}),
            new preguntados("¿Quién escribió la obra 'Romeo y Julieta'?", new string[]{"William Shakespeare", "Jane Austen", "Charles Dickens", "Miguel de Cervantes"}, new string[]{"William Shakespeare"}),
            new preguntados("¿Cómo se llama tu mascota?", new string[]{"Max", "Charlie", "Demon", "Leo"}, new string[]{"Demon"}),
            new preguntados("¿Estas solo en casa?", new string[]{"Si", "Si","No", "No"}, new string[]{"Si", "No"}),
            new preguntados("¿Seguro?", new string[]{"Si", "Si","No", "No"}, new string[]{"Si", "No"}),
            new preguntados("¿Donde tienes la puerta?", new string[]{"Izquierda", "Derecha","Delante", "Atras"}, new string[]{"Izquierda", "Derecha","Delante", "Atras"}),
            new preguntados("¿Estás disfrutando del juego?", new string[]{"Si", "Si","No", "No"}, new string[]{"Si"}),
        };
       // currentQuestionIndex = -1;
        preguntasAcertadas = 0; // Inicializa el contador de preguntas acertadas
        ShowNextQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(delegate { OnAnswerButtonClick(buttonIndex); });
        }
    }

    void OnAnswerButtonClick(int buttonIndex)
    {
        string selectedAnswer = cultura[currentQuestionIndex].answers[buttonIndex];
        CheckAnswer(selectedAnswer);
    }

    void ShowNextQuestion()
    {
        if (preguntasAcertadas == 0)
        {
            currentQuestionIndex = UnityEngine.Random.Range(0, 3);
        }
        else if (preguntasAcertadas == 1)
        {
            currentQuestionIndex = UnityEngine.Random.Range(3, 5);
        }
        else if (preguntasAcertadas == 2)
        {
            currentQuestionIndex = 6;
        }
        else if (preguntasAcertadas == 3)
        {
            currentQuestionIndex = 7;
        }
         else if (preguntasAcertadas == 4)
        {
            currentQuestionIndex = 8;
        }
        else if (preguntasAcertadas == 5)
        {
            currentQuestionIndex = 9;
        }
        else if (preguntasAcertadas == 6)
        {
            currentQuestionIndex = 10;
        }
        
        if (currentQuestionIndex < cultura.Length)
        {
            preguntados currentQuestion = cultura[currentQuestionIndex];
            questionText.text = currentQuestion.question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
            }
        }
        else
        {
            Debug.Log("Se han mostrado todas las preguntas.");
        }
    }

    IEnumerator HideContadorResta()
    {
        yield return new WaitForSeconds(1f);
        contadorResta.gameObject.SetActive(false);
    }

    public void CheckAnswer(string selectedAnswer)
    {
        preguntados currentQuestion = cultura[currentQuestionIndex];
        bool isCorrect = false;
        foreach (string correctAnswer in currentQuestion.correctAnswer)
        {
            if (selectedAnswer == correctAnswer)
            {
                isCorrect = true;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Respuesta correcta");
            questionText.text = "¡Felicidades, has ganado!";
            preguntasAcertadas++; // Incrementa el contador de preguntas acertadas
            ShowNextQuestion();
            if (preguntasAcertadas >= 7) // Si se aciertan 3 preguntas, cambia de escena
            {
                numJuegosCompletados = PlayerPrefs.GetInt("JuegosCompletados");
                numJuegosCompletados += 1;
                PlayerPrefs.SetInt("JuegosCompletados", numJuegosCompletados);
                SceneManager.LoadScene("EscenaPrincipal");
            }
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            contadorResta.gameObject.SetActive(true);
            StartCoroutine(HideContadorResta());
            contadorScript.JuegoPerdido(5);
        }
    }
}

[System.Serializable]
public class preguntados
{
    public string question;
    public string[] answers;
    public string[] correctAnswer;

    public preguntados(string q, string[] a, string[] correct)
    {
        this.question = q;
        this.answers = a;
        this.correctAnswer = correct;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{

    int tiempoRestante;
    public TMP_Text contadorResta;
    public TMP_Text contador;

    // Start is called before the first frame update
    void Start()
    {   

        tiempoRestante = PlayerPrefs.GetInt("TiempoRestante");

        contador.text = tiempoRestante.ToString();

        Debug.Log("Tiempo restante: " + tiempoRestante);

        InvokeRepeating("RestarTiempo", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
public void JuegoPerdido(int restar)
    {
        tiempoRestante -= restar; // Resta 1 segundo al tiempo restante
        Debug.Log("Tiempo restante: " + tiempoRestante);

        if (tiempoRestante <= 0)
        {
            // Realizar alguna acci�n cuando el tiempo se acabe
            Debug.Log("Tiempo agotado");
            CancelInvoke(); // Detiene la llamada repetida a la funci�n RestarTiempo
        }

        contador.text = tiempoRestante.ToString();
        PlayerPrefs.SetInt("TiempoRestante", tiempoRestante);
        PlayerPrefs.Save();
    }
    void RestarTiempo()
    {
        tiempoRestante -= 1; // Resta 1 segundo al tiempo restante
        Debug.Log("Tiempo restante: " + tiempoRestante);

        if (tiempoRestante <= 0)
        {
            // Realizar alguna acci�n cuando el tiempo se acabe
            Debug.Log("Tiempo agotado");
            CancelInvoke(); // Detiene la llamada repetida a la funci�n RestarTiempo
            //SceneManager.LoadScene("EscenaMuerte");
        }

        contador.text = tiempoRestante.ToString();
        PlayerPrefs.SetInt("TiempoRestante", tiempoRestante);
        PlayerPrefs.Save();
    }
}

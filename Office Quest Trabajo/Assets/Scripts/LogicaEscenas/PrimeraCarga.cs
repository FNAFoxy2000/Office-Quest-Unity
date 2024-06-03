using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraCarga : MonoBehaviour
{
    int juegosCompletados;
    int tiempoRestante;
    int digito1;
    int digito2;
    int digito3;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("CREANDO datos...");
        //Posicion jugador
        PlayerPrefs.SetFloat("PlayerX", 0.0f);
        PlayerPrefs.SetFloat("PlayerY", 0.5f);
        PlayerPrefs.SetFloat("PlayerZ", 5.0f);

        juegosCompletados = 0;
        PlayerPrefs.SetInt("JuegosCompletados", juegosCompletados);

        tiempoRestante = 100;
        PlayerPrefs.SetInt("TiempoRestante", tiempoRestante);

        PlayerPrefs.SetInt("2DCompletado", 0);


        digito1 = Random.Range(0, 10);
        digito2 = Random.Range(0, 10);
        digito3 = Random.Range(0, 10);

        PlayerPrefs.SetInt("Digito1", digito1);
        PlayerPrefs.SetInt("Digito2", digito2);
        PlayerPrefs.SetInt("Digito3", digito3);
        PlayerPrefs.SetInt("mostrarDigito1", 0);
        PlayerPrefs.SetInt("mostrarDigito2", 0);
        PlayerPrefs.SetInt("mostrarDigito3", 0);
        Debug.Log("Número aleatorio de 3 dígitos: " + digito1 + "" + digito2 + "" + digito3);

        // Para asegurarte de que los datos se guarden en el disco, llama a PlayerPrefs.Save()
        PlayerPrefs.Save();

    }
    // Update is called once per frame
    void Update()
    {

    }
}

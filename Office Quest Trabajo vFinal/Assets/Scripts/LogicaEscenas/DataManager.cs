using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    private string filePath;
    private string jugador;
    private int puntuacion;

    public Button bMostrarTable;
    public GameObject tablaPuntuaciones;
    public Text plantillaTexto;
    public TMP_Text TextoScaped;
    public TMP_Text TextoThanks;
    public TMP_Text TableScore;
    private void Start()
    {
        tablaPuntuaciones.SetActive(false);
        TableScore.gameObject.SetActive(false);
        bMostrarTable.onClick.AddListener(MostrarPuntuaciones);

        filePath = Application.persistentDataPath + "/datos.txt";
        Debug.Log("Ruta del archivo: " + filePath);

        // Crear el archivo inicial con los encabezados si no existe
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Jugadores : ");
                writer.WriteLine("Puntuaciones : ");
            }
        }

        jugador = PlayerPrefs.GetString("UserName");
        puntuacion = PlayerPrefs.GetInt("TiempoRestante");
        GuardarJugadorYPuntuacion(jugador, puntuacion);
    }

    public void GuardarJugadorYPuntuacion(string jugador, int puntuacion)
    {
        List<string> lines = new List<string>(File.ReadAllLines(filePath));

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Jugadores :"))
            {
                lines[i] += $" {jugador},";
            }
            else if (lines[i].StartsWith("Puntuaciones :"))
            {
                lines[i] += $" {puntuacion},";
            }
        }

        File.WriteAllLines(filePath, lines);
        Debug.Log("Datos Guardados");
    }

    public List<(string, int)> CargarDatos()
    {
        List<(string, int)> datos = new List<(string, int)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string[] jugadores = null;
            string[] puntuaciones = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("Jugadores :"))
                {
                    jugadores = line.Replace("Jugadores :", "").Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                }
                else if (line.StartsWith("Puntuaciones :"))
                {
                    puntuaciones = line.Replace("Puntuaciones :", "").Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                }
            }

            if (jugadores != null && puntuaciones != null && jugadores.Length == puntuaciones.Length)
            {
                for (int i = 0; i < jugadores.Length; i++)
                {
                    int puntuacion;
                    if (int.TryParse(puntuaciones[i].Trim(), out puntuacion))
                    {
                        datos.Add((jugadores[i].Trim(), puntuacion));
                    }
                }
            }
        }
        else
        {
            Debug.LogError("El archivo de datos no existe.");
        }

        return datos;
    }

    private void MostrarPuntuaciones()
    {
        // Ocultar el botón
        bMostrarTable.gameObject.SetActive(false);
        TextoScaped.gameObject.SetActive(false);
        TextoThanks.gameObject.SetActive(false);

        // Mostrar la tabla de puntuaciones
        tablaPuntuaciones.SetActive(true);
        TableScore.gameObject.SetActive(true);

        // Limpiar la tabla de puntuaciones antes de llenarla
        foreach (Transform child in tablaPuntuaciones.transform)
        {
            Destroy(child.gameObject);
        }

        // Cargar datos y poblar la tabla
        List<(string, int)> datosCargados = CargarDatos();
        foreach (var kvp in datosCargados)
        {
            Text nuevoTexto = Instantiate(plantillaTexto, tablaPuntuaciones.transform);
            nuevoTexto.text = $"{kvp.Item1} : {kvp.Item2}";
            nuevoTexto.gameObject.SetActive(true);
            nuevoTexto.enabled = true;
        }
        Debug.Log("Datos cargados");
    }
}

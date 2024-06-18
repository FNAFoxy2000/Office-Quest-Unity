using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;
	private Camera mainCamera;
	public Transform capsula2;

	void Start()
	{
		// Obtener la cámara principal
		mainCamera = Camera.main;
	}
	void Update()
    {
		barraVida.fillAmount = vidaActual / vidaMaxima;
		
		if (vidaActual == 0 || Input.GetKeyDown(KeyCode.R))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }

    public void hit(float cantidadDeDanio)
    {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		vidaActual -= cantidadDeDanio;
        Debug.Log("pega");
        if (vidaActual == 0)
        {
			Vector3 targetPosition = new Vector3(0, 0.87f, -29.5f);
			player.transform.position = targetPosition;
			mainCamera.transform.position = targetPosition;
		}

         barraVida.fillAmount = vidaActual / vidaMaxima;
    }
    //    SceneManager.LoadScene("Menu");
}



using TMPro;
using UnityEngine;

public class cargarN2 : MonoBehaviour
{
	public Transform capsula2;
	private bool JugadorDentro = false;
	private Camera mainCamera;

    public TMP_Text pulsaE;

    void Start()
	{
		// Obtener la cámara principal
		mainCamera = Camera.main;
	}

	void Update()
	{
		// Si el jugador presiona la tecla "E" y está dentro de la cápsula
		if (Input.GetKeyDown(KeyCode.E) && JugadorDentro)
		{
			// Cambiar la posición del jugador a la de la capsula2
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
			{
				player.transform.position = capsula2.position;
			}

			// Cambiar la posición de la cámara a la de la capsula2
			if (mainCamera != null)
			{
				mainCamera.transform.position = new Vector3(capsula2.position.x, capsula2.position.y, mainCamera.transform.position.z);
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Verificar si el objeto que entra en el collider es el jugador
		if (other.CompareTag("Player"))
		{
			JugadorDentro = true;
            pulsaE.gameObject.SetActive(true);
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		// Verificar si el objeto que sale del collider es el jugador
		if (other.CompareTag("Player"))
		{
			JugadorDentro = false;
            pulsaE.gameObject.SetActive(false);
        }
	}
}

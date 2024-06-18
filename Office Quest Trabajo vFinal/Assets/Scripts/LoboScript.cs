using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboScript : MonoBehaviour
{
	public float velocidad = 5f;
	public float distanciaDePersecucion = 1f;
	public float distanciaGolpe = 1.5f;
	public float cantidadDanio = 10f;
	public BarraDeVida barraDeVida;
	public int Health ;
	public GameObject caballero;
	private Transform caballeroTransform;
	private Animator animator;
	private bool facingRight = true;

	private float timerGolpe = 0f;
	public float tiempoEntreGolpes = 3f;

	private void Start()
	{
		animator = GetComponent<Animator>();

		if (caballero != null)
		{
			caballeroTransform = caballero.transform;
		}
		else
		{
			Debug.LogError("No se encontró el objeto con la etiqueta 'Caballero'. Asegúrate de asignar la etiqueta correctamente.");
		}
	}

	private void Update()
	{
		if (caballeroTransform == null) return;

		timerGolpe += Time.deltaTime;

		GirarSprite();

		Vector3 direccionAlCaballero = caballeroTransform.position - transform.position;
		float distanciaAlCaballero = direccionAlCaballero.magnitude;

		// Si el caballero está dentro del rango de persecución, mover el lobo hacia él
		if (distanciaAlCaballero <= distanciaDePersecucion)
		{
			transform.Translate(direccionAlCaballero.normalized * velocidad * Time.deltaTime);
		}

		// Si el caballero está dentro del rango de golpe y es tiempo de golpear, golpear al caballero
		if (distanciaAlCaballero <= distanciaGolpe && timerGolpe >= tiempoEntreGolpes)
		{
			Debug.Log("Golpe al Caballero");

			if (barraDeVida != null)
			{
				barraDeVida.hit(cantidadDanio);
				Debug.Log(cantidadDanio);
				ActivarAnimacionGolpear();
				timerGolpe = 0f;

				// Desactivar la animación después de un tiempo (ajusta el tiempo según tus necesidades)
				StartCoroutine(DesactivarAnimacionGolpearDespuesDeTiempo(1f));
			}
		}
	}

	private void GirarSprite()
	{
		if (caballeroTransform.position.x > transform.position.x && !facingRight || caballeroTransform.position.x < transform.position.x && facingRight)
		{
			facingRight = !facingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}

	public void Hit()
	{
		Health = Health - 1;
		if (Health == 0) Destroy(gameObject);
	}

	private void ActivarAnimacionGolpear()
	{
		animator.SetTrigger("Atack");
	}

	private IEnumerator DesactivarAnimacionGolpearDespuesDeTiempo(float tiempo)
	{
		yield return new WaitForSeconds(tiempo);
		animator.ResetTrigger("Atack");
	}
}

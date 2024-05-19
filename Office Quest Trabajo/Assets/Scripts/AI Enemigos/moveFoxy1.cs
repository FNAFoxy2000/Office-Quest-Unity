using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class moveFoxy1 : MonoBehaviour
{
    private Vector3 lastPosition;
    public Vector3 jumpPosition;
    private bool isMoving;
    public Animator animator;
    private bool jumpscare = false;

    private NavMeshAgent navMeshAgent;

    public AudioSource[] audioSources;

    public AudioClip jumpScreamer;
    public AudioClip otherSound;
    private bool jumpScreamerPlayed = false;

    public bool run = false;
    public AIFoxy aiFoxy;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Inicializa la posici�n inicial del enemigo
        lastPosition = transform.position;

        audioSources = GetComponents<AudioSource>();

        if (audioSources == null || audioSources.Length == 0)
        {
            Debug.LogError("No hay componentes AudioSource adjuntos al GameObject.");
        }
    }

    void Update()
    {
        if (transform.position == jumpPosition)
        {
            jumpscare = true;
        }

        if (jumpscare == false)
        {

            // Compara la posici�n actual con la posici�n del �ltimo fotograma
            if (transform.position != lastPosition)
            {
                // El enemigo se est� moviendo
                isMoving = true;
            }
            else
            {
                // El enemigo no se est� moviendo
                isMoving = false;
            }

            // Guarda la posici�n actual para la siguiente comparaci�n
            lastPosition = transform.position;


            // Puedes imprimir en la consola si el enemigo se est� moviendo o no
            if (isMoving)
            {
                animator.SetFloat("Blend", 0.5f, 0.5f, Time.deltaTime);

            }
            else
            {
                animator.SetFloat("Blend", 0f, 0.5f, Time.deltaTime);
            }
        }
        else
        {
            //navMeshAgent.isStopped = true;
            animator.SetTrigger("Jumpscare");
            if (audioSources != null && audioSources.Length > 0 && jumpScreamerPlayed == false)
            {
                // Reproduce el primer sonido (jumpSound) en este caso
                audioSources[0].PlayOneShot(jumpScreamer);
                jumpScreamerPlayed = true;
            }
            //animator.SetFloat("VelZ", 2);
            navMeshAgent.enabled = false;
            Invoke("LoadDeathScene", 3f);
        }

    }

    void LoadDeathScene()
    {
        SceneManager.LoadScene("Backrooms");
    }
}

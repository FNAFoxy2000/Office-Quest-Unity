using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIFoxy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    public Transform playerTransform;

    private int i = 0;

    public GameObject player;

    private bool updateOn = true;

    public bool followPlayer;
    private float distanceToPlayer;
    public float distanceToFollow = 10;
    private float fieldOfViewAngle = 135;

    // jumpscare
    public Camera CameraPlayer;
    public Camera CameraJumpscare;

    public Vector3 teleportRotationE = new Vector3(0f, 90f, 0f);

    public Transform enemyTransform;
    public Vector3 teleportPositionE;

    public Animator animator;
    public bool run = false;

    void Start()
    {
        SetCameraActiveState(false);

        navMeshAgent.destination = destinations[0].transform.position;
        //player = FindObjectOfType<PlayerMovement>().gameObject;

        navMeshAgent.speed = 2;

    }


    void Update()
    {
        if (updateOn == true && navMeshAgent.enabled == true)
        {


            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= distanceToFollow && followPlayer)
            {
                followToPlayer();
                //// Calcula el ángulo entre la dirección hacia adelante del enemigo y la dirección hacia el jugador
                //Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                //float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

                //// Si el ángulo está dentro del rango de visión
                //if (angleToPlayer <= fieldOfViewAngle * 0.5f)
                //{
                //    // El jugador está dentro del rango de visión, ejecuta la función followToPlayer
                //    followToPlayer();
                //}
            }
            else
            {

                navMeshAgent.speed = 2;
                enemyPath();
            }

            if (distanceToPlayer <= 3)
            {
                PlayerDeath();
            }


        }
        // Ejemplo: Teletransportar al jugador y al enemigo a la posición específica cuando se presiona la tecla T
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCameraActivation();
            TeleportEntities();
        }

    }

    public void enemyPath()
    {

        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) < 3)
        {
            navMeshAgent.isStopped = true;
            StartCoroutine(esperar5segundos());

            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

    }

    IEnumerator esperar5segundos()
    {
        yield return new WaitForSeconds(5f);
        navMeshAgent.isStopped = false;
    }

    public void followToPlayer()
    {
        animator.SetFloat("Blend", 1f, 0.1f, Time.deltaTime);
        navMeshAgent.speed = 4;
        navMeshAgent.destination = player.transform.position;

    }

    void PlayerDeath()
    {
        Debug.Log("¡El jugador ha muerto!");
        updateOn = false;
        Cursor.lockState = CursorLockMode.None;
        ToggleCameraActivation();
        TeleportEntities();

    }

    void ToggleCameraActivation()
    {
        // Si la cámara inactiva está activa, cambia a la cámara del jugador
        if (CameraJumpscare.gameObject.activeSelf)
        {
            SwitchToPlayerCamera();
        }
        else
        {
            // Cambia a la cámara inactiva
            SetCameraActiveState(!CameraJumpscare.gameObject.activeSelf);
        }
    }

    void SetCameraActiveState(bool isActive)
    {
        // Activa o desactiva la cámara inactiva según el estado proporcionado
        CameraJumpscare.gameObject.SetActive(isActive);

        // Activa o desactiva la cámara del jugador según el estado contrario
        CameraPlayer.gameObject.SetActive(!isActive);

        // Muestra un mensaje en la consola para confirmar el cambio
        if (isActive)
        {
            Debug.Log("Cámara activada y cambiada a la cámara inactiva.");
        }
        else
        {
            Debug.Log("Cámara inactiva desactivada y cambiada a la cámara del jugador.");
        }
    }

    void SwitchToPlayerCamera()
    {
        // Desactiva la cámara inactiva
        CameraJumpscare.gameObject.SetActive(false);

        // Activa la cámara del jugador
        CameraPlayer.gameObject.SetActive(true);
    }


    void TeleportEntities()
    {
        // Teletransportar al enemigo a la posición específica
        if (enemyTransform != null)
        {
            enemyTransform.rotation = Quaternion.Euler(teleportRotationE);
            enemyTransform.position = teleportPositionE;
            Debug.Log("El enemigo se ha teletransportado a la posición específica.");
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIFoxy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;

    private int currentDestinationIndex = 0;
    public GameObject player;


    public float distanceToFollow = 7f;
    public float distanceToKill = 2f;
    private float fieldOfViewAngle = 135f;

    // Jumpscare variables
    public Camera CameraPlayer;
    public Camera CameraJumpscare;

    public Vector3 teleportRotationE = new Vector3(0f, 0f, 0f);
    public Transform enemyTransform;
    public Vector3 teleportPositionE;

    public Animator animator;
    public bool run = false;

    private Vector3 lastPosition;
    public Vector3 jumpPosition;
    private bool isMoving;
    private bool jumpscare = false;

    public AudioSource audioJumpscare;
    public AudioSource audioPasos;
    public AudioSource audioCorrer;
    public AudioClip jumpScreamer;
    private bool jumpScreamerPlayed = false;
    private bool pasosPlayed = false;
    private bool correrPlayed = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lastPosition = transform.position;

        SetCameraActiveState(false);

        navMeshAgent.destination = destinations[0].position;
        player = FindObjectOfType<PlayerMovement>().gameObject;

        navMeshAgent.speed = 2;
    }

    void Update()
    {
        if (transform.position == jumpPosition)
        {
            jumpscare = true;
        }

        if (!jumpscare && navMeshAgent.enabled)
        {
            CheckMovementStatus();
            DetectAndChasePlayer();
        }
        else
        {
            TriggerJumpscare();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCameraActivation();
            TeleportEntities();
        }

    }

    void CheckMovementStatus()
    {
        if (transform.position != lastPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = transform.position;

        if (isMoving)
        {
            animator.SetFloat("Blend", 0.5f, 0.5f, Time.deltaTime);
            if(pasosPlayed == false)
            {
                pasosPlayed = true;
                audioPasos.loop = true;
                audioPasos.Play();
            }
            
        }
        else
        {
            animator.SetFloat("Blend", 0f, 0.5f, Time.deltaTime);
            audioCorrer.Stop();
            audioPasos.Stop();
            pasosPlayed = false;
            correrPlayed = false;
        }
    }

    void DetectAndChasePlayer()
    {
        float distanceToPlayer;
        Vector3 positionEnemy;
        Vector3 positionPlayer;
        positionEnemy = new Vector3(transform.position.x, 0, transform.position.z);
        positionPlayer = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        distanceToPlayer = Vector3.Distance(positionEnemy, positionPlayer);
        //Debug.Log("Distancia al jugador: " + distanceToPlayer);
        //Debug.Log("Posicion del enemigo: "+ positionEnemy);
        //Debug.Log("Posicion del jugador: "+ positionPlayer);
        if (distanceToPlayer <= distanceToKill) {
            PlayerDeath();
        }
        if (distanceToPlayer <= distanceToFollow)
        {
            //followToPlayer(positionPlayer);
            Vector3 directionToPlayer = (positionPlayer - positionEnemy).normalized;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= fieldOfViewAngle * 0.5f)
            {

                followToPlayer(positionPlayer);
            }
        }
        else
        {
            audioCorrer.Stop();
            correrPlayed = false;
            //Debug.Log("Restableciendo ruta");
            navMeshAgent.speed = 2f;
            enemyPath();
        }

    }

    void enemyPath()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            navMeshAgent.destination = destinations[currentDestinationIndex].position;

            if (Vector3.Distance(transform.position, destinations[currentDestinationIndex].position) < 2)
            {
                navMeshAgent.isStopped = true;
                StartCoroutine(WaitBeforeMoving());

                currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Length;
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(5f);
        navMeshAgent.isStopped = false;
    }

    void followToPlayer(Vector3 positionPlayer)
    {
        //Debug.Log("Seguir a jugador");
        animator.SetFloat("Blend", 1f, 0.1f, Time.deltaTime);
        navMeshAgent.speed = 3f;
        navMeshAgent.destination = positionPlayer;
        audioPasos.Stop();
        pasosPlayed = false;
        if(correrPlayed == false)
        {
            correrPlayed = true;
            audioCorrer.loop = true;
            audioCorrer.Play();
        }
        
    }

    void PlayerDeath()
    {
        navMeshAgent.enabled = false;
        Debug.Log("¡El jugador ha muerto!");
        //updateOn = false;
        Cursor.lockState = CursorLockMode.None;
        ToggleCameraActivation();
        TeleportEntities();
    }

    void TriggerJumpscare()
    {
        navMeshAgent.enabled = false;
        animator.SetTrigger("Jumpscare");
        if (!jumpScreamerPlayed)
        {
            Debug.Log("Jumpscare");
            audioJumpscare.Play();
            jumpScreamerPlayed = true;
            audioPasos.Stop();
            audioCorrer.Stop();
        }
        Invoke("LoadDeathScene", 3f);
    }

    void ToggleCameraActivation()
    {
        SetCameraActiveState(!CameraJumpscare.gameObject.activeSelf);
    }

    void SetCameraActiveState(bool isActive)
    {
        CameraJumpscare.gameObject.SetActive(isActive);
        CameraPlayer.gameObject.SetActive(!isActive);
    }

    void TeleportEntities()
    {
        if (enemyTransform != null)
        {
            enemyTransform.rotation = Quaternion.Euler(teleportRotationE);
            enemyTransform.position = teleportPositionE;
            Debug.Log("El enemigo se ha teletransportado a la posición específica.");
            navMeshAgent.enabled = false;
        }
    }

    void LoadDeathScene()
    {
        SceneManager.LoadScene("Backrooms");
    }
}


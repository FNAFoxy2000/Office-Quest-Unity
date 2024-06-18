using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nuevo : MonoBehaviour
{
    public float JumpForce;
    public GameObject BulletPrefab;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float Horizontal;
    private bool Grounded;
    private float LastShoot;
    //private int Health = 5;
    private bool Atack = false;
    //private bool CanTeleport = false;
    public Transform capsula2;
	public Transform newPosition; // Nueva posición a la que se moverá el personaje
	public Camera mainCamera; // Referencia a la cámara principal
	public GameObject enemy; // Referencia al objeto del enemigo
	
	void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
            transform.localScale = new Vector3(-0.60f, 0.60f, 0.60f);
        else if (Horizontal > 0.0f)
            transform.localScale = new Vector3(0.60f, 0.60f, 0.60f);

        Animator.SetBool("Running", Horizontal != 0.0f && !Atack);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.3f);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.5f)
        {
            StartCoroutine(Shoot());
            LastShoot = Time.time;
        }
		if (enemy == null)
		{
            // Cambiar a la nueva escena
            PlayerPrefs.SetInt("2DCompletado", 1);
            SceneManager.LoadScene("EscenaPrincipal");
		}
		//if (Input.GetKeyDown(KeyCode.E) && CanTeleport)
		//{
		//	Teleport();
		//}
		//Debug.Log(CanTeleport);


	}

	private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private IEnumerator Shoot()
    {
        Atack = true;
        Animator.SetBool("Atack", true);

        yield return new WaitForSeconds(0.3f);  // Esperar 0.5 segundos

        Vector3 direction = transform.localScale.x == 0.60f ? Vector2.right : Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.15f);  // Ajusta este tiempo según la duración de la animación de ataque
        Atack = false;
        Animator.SetBool("Atack", false);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    //public void Hit()
    //{
    //    Health -= 1;
    //    //if (Health == 0) Destroy(gameObject);
    //    if (Health == 0)
    //    {
    //        // Cambiar posición del personaje y de la cámara a la misma nueva posición
    //        Vector3 targetPosition = new Vector3(0, 0.87f, -29.5f);
    //        transform.position = targetPosition;
    //        mainCamera.transform.position = targetPosition;

    //        // Reiniciar la salud del personaje
    //        Health = 5;
    //    }
    //}
}

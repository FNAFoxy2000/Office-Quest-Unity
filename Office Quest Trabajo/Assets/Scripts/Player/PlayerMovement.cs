using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed=10f;
    public float gravity=-9.81f;
    public Animator animator;
    public Transform groundCheck;
    
    public float sphereRadius = -0.3f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;
    public float jumpHeigh= 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0 ){
            velocity.y= -2f;

        }

        float x= Input.GetAxis("Horizontal"); 
        float z= Input.GetAxis("Vertical");
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelZ", z);
        Vector3 move= transform.right * x + transform.forward*z;

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeigh*-2*gravity);
        }
        velocity.y += gravity*Time.deltaTime;
        characterController.Move(move*speed*Time.deltaTime);
        characterController.Move(velocity*Time.deltaTime);
    }
}

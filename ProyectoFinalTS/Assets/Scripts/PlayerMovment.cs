using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] CharacterController controller;

    [SerializeField] float playerSpeed = 12.0f;

    [SerializeField] float gravity = -9.81f;

    [SerializeField] Transform GroundCheck;

    [SerializeField] float groundDistance = 0.5f;

    [SerializeField] LayerMask groundMask;

    [SerializeField] float jumpHeight = 3f;

    [SerializeField] Joystick joystick;

    Vector3 playerVelocity;
    bool isGrounded;

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement;
        float zMovement;

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

       if( isGrounded && playerVelocity.y < 0)
        {
           playerVelocity.y = -2f;
        }



#if UNITY_EDITOR
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");
#else
        xMovement = joystick.Horizontal;
        zMovement = joystick.Vertical;
#endif
        Vector3 move = transform.right * xMovement + transform.forward * zMovement;

        controller.Move(move * playerSpeed * Time.deltaTime );

        playerVelocity.y += (gravity * Time.deltaTime);
         
        controller.Move(playerVelocity * Time.deltaTime );


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        if (transform.position.y < 0)
        {
            Target target = gameObject.GetComponent<Target>();
            target.Die();
        }
            
    }
}

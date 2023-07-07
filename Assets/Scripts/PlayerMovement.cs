using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -2.5f;
    public float jumpHeight = 100f;
    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    private bool isJumping=false;

    Vector3 lastPosition;
    Vector3 velocity;
    bool isGrounded;
    float originalSpeed;
    public float acceleration=10f;
    float normalHeight;
    public float crouchHeight;
    public bool isCrouch;
    public float crouchSpeed=4;

    private PlayerStats stats;

    public AudioSource source;
    public AudioClip clipWalk;
    public AudioClip clipJump;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        normalHeight = controller.height;
        stats=gameObject.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //wil create a sphere at the groundcheck object

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = acceleration;
        }
        else if (!isCrouch)
        {
            speed = originalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouch)
            {
                controller.height = normalHeight / 3;
                speed = crouchSpeed;
                isCrouch = true;
            }

            else
            {
                controller.height = normalHeight;
                speed = originalSpeed;
                isCrouch = false;
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //reset velocity
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
 
        controller.Move(move * speed * Time.fixedDeltaTime);

        
            if (!source.isPlaying && !move.Equals(Vector3.zero) && isGrounded)
            {
                source.PlayOneShot(clipWalk);
              
            }
          

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = acceleration;
        }
        else if(!isCrouch)
        {
            speed = originalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouch)
            {
                controller.height = normalHeight / 3;
                speed = crouchSpeed;
                isCrouch = true;
            }

            else
            {
                controller.height = normalHeight;
                speed = originalSpeed;
                isCrouch = false;
            }
        }

        if (isJumping)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            controller.Move(velocity * Time.fixedDeltaTime);
            if (!source.isPlaying)
            {
                source.PlayOneShot(clipJump);
            }
            isJumping = false;
        }

        if (velocity.y <= -35)
        {
            stats.UpdateHealthBar(-0.5f);
        }

        velocity.y += gravity + Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }


}

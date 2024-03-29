using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public ParticleSystem watersplash;
    [Header("Movement")]
    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
    public float deacceleration = 4; //brake power

    float velocityX; //Our current velocity

    [Header("Jump")]
    public float jumpPower = 12; //How strong our jump is
    public float groundCheckDistance = 0.1f; //how far outsie our character we should raycast
    

    bool onGround = true; //checks if we are on the ground
    float groundCheckLenght; //Length of the raycast
    int maxJumps = 2; //We added a double jump to the game
    int currentJumps = 0;

    Rigidbody2D rb2D; //Ref to our rigidbody

    //Grappling hook Platform
    private LineRenderer lineRend;
    private DistanceJoint2D distJoint;
    private GrapplingPoint selectedUpperPlatform;
    private float catchFlySpeed = 20;
    

    //walk animation
    public Animator walkAnimation;

    //sound
    public AudioClip jumpSound;
    public AudioClip grappleSound;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Change project setting for raycast since they start inside colliders
        Physics2D.queriesStartInColliders = false;

        rb2D = GetComponent<Rigidbody2D>(); //assign our ref.

        //Garppling hook
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();

        lineRend.enabled = false;
        distJoint.enabled = false;
        selectedUpperPlatform = null;
        

        //Calculate player size based on our colliders, lenght of raycast
        var collider = GetComponent<Collider2D>();
        groundCheckLenght = collider.bounds.size.y + groundCheckDistance;
    }

    void Update()
    {
        HorizontalMovement(); //Handles Horizontal movement

        Jump(); //handles jump

        GravityAdjust(); //adjusts gravity

        GrapplingBehaviourPlatform(); //platform grapple

        
    }

    private void GravityAdjust()
    {
        //If we are falling down increase gravity x4
        //This creates a much better feeling, less floaty
        if (rb2D.velocity.y < 0)
            rb2D.gravityScale = 4;
        else
            rb2D.gravityScale = 1;
    }

    private void Jump()
    {

        //if we press the button and have jumps remaining
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            currentJumps++;
            //Apply our jump power in the y direction
            var velocity = rb2D.velocity;
            velocity.y = jumpPower;
            rb2D.velocity = velocity;
            //createSplash();
            PlaySound(jumpSound);

        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            //Cut the jump short by reducing the upward velocity.
            //Same result as button down but on one line.
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.25f);
        }

        //Raycast, check if there is anything under us.
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLenght);

        //Restet our counter if we are on the ground.
        if (onGround)
            currentJumps = 0;
            

    }

    private void HorizontalMovement()
    {
        //Get the raw input
        float x = Input.GetAxisRaw("Horizontal");
        

        // Flip the character if moving to the left
        if (x < 0)
        {
            // Set the local scale to flip the character horizontally
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        // Reset the character's scale when moving right
        else if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }

        if (x != 0)
        {
            // Player is moving horizontally
            
            velocityX += x * acceleration * Time.deltaTime;
            walkAnimation.SetBool("Walking", true); // Set the IsMoving parameter to true
            

        }
        else
        {
            // Player is not moving
            walkAnimation.SetBool("Walking", false); // Set the IsMoving parameter to false
        }

        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocityX += x * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        //If we have zero input from the player
        //(x < 0 == velocityX > 0) checks if input is in the opposite direction of movement
        if (x == 0 || (x < 0 == velocityX > 0))
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);

        //test
        if (!onGround)
        {
            float extraAirMovement = 2.0f; // You can adjust this value
            rb2D.AddForce(Vector2.right * x * extraAirMovement);
        }

        

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Grappling(GrapplingPoint upperPlatform)
    {
        selectedUpperPlatform = upperPlatform;
    }

    public void StopGrappling()
    {
        selectedUpperPlatform = null;
        
    }


    public void GrapplingBehaviourPlatform()
    {
        //om vi inte grapplar g�r inget
        if (selectedUpperPlatform == null)
        {
            lineRend.enabled = false;
            distJoint.enabled = false;

            return;
        }

        //om vi grapplar
        PlaySound(grappleSound);
        lineRend.enabled=true;
        distJoint.enabled=true;
        

        distJoint.connectedBody = selectedUpperPlatform.GetComponent<Rigidbody2D>();

       //om man grapplat fast, s�tt linerender to our current position fr�n 0
       //detta skapar 2 punkter som linjen g�r emellan dvs platform och spelare
        if (selectedUpperPlatform != null)
        {
            lineRend.SetPosition(0,transform.position);
            lineRend.SetPosition(1, selectedUpperPlatform.transform.position);

            //test
            // Check if the selected object has the "fly" tag
            if (selectedUpperPlatform.CompareTag("fly") || selectedUpperPlatform.CompareTag("worm"))
            {
                // Move the object towards the player
                // Calculate the direction from the object to the player
                Vector3 direction = (transform.position - selectedUpperPlatform.transform.position).normalized;

                // Set the object's position to move towards the player
                float speed = catchFlySpeed;
               

                selectedUpperPlatform.transform.position += direction * speed * Time.deltaTime;
                
            }

  

            else
            {
                // Move the player towards the object
                float desiredDistance = Vector2.Distance(transform.position, selectedUpperPlatform.transform.position);
                Vector3 targetPosition = Vector3.Lerp(transform.position, selectedUpperPlatform.transform.position, Time.deltaTime);
                transform.position = targetPosition;
            }


      

        }

    }

    private void PlaySound(AudioClip soundClip)
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }


    //void createSplash()
    //{
    //    watersplash.Play();
    //}


}



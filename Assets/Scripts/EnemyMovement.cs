using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Speed of movement
    public float minChangeInterval = 1.0f; // Minimum time before changing direction
    public float maxChangeInterval = 4.0f; // Maximum time before changing direction
    private float changeDirectionTimer; // Timer for changing direction
    private Vector3 initialPosition; // Initial position of the GameObject
    private float maxDistance; // Maximum distance to move in one direction
    private bool movingRight = true; // Flag to track the current direction

    void Start()
    {
        initialPosition = transform.position;
        maxDistance = Random.Range(1.0f, 5.0f); // Set an initial random distance
        changeDirectionTimer = Random.Range(minChangeInterval, maxChangeInterval);
    }

    void Update()
    {
        // Update the timer
        changeDirectionTimer -= Time.deltaTime;

        // Check if it's time to change direction
        if (changeDirectionTimer <= 0)
        {
            changeDirectionTimer = Random.Range(minChangeInterval, maxChangeInterval); // Reset the timer

            // Change direction
            movingRight = !movingRight;

            // Generate a new random distance
            maxDistance = Random.Range(1.0f, 5.0f);
        }

        if (movingRight)
        {
            //Test
            // Set the local scale to flip the character horizontally
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Calculate movement
        Vector3 movement = Vector3.right * (movingRight ? 1 : -1) * moveSpeed * Time.deltaTime;

        // Move the GameObject
        transform.Translate(movement);

        // Check if it has reached the maximum distance in the current direction
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= maxDistance)
        {
            // Change direction
            movingRight = !movingRight;

            // Generate a new random distance
            maxDistance = Random.Range(1.0f, 5.0f);
        }


    }

}

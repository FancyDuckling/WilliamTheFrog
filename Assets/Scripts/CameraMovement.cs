using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + 6f; // Lock the camera to the player on the X-axis
        transform.position = newPosition;

        //transform.position = player.transform.position + new Vector3(6f,3f,-10);
    }
}

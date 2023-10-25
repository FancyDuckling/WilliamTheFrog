using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(6f,3f,-10);
    }
}

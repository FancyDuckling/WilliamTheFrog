using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    //public GameObject crosshair;

    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos.z = 0; 
        transform.position = mousePos;
    }

}

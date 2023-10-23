using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFlyToFrog : MonoBehaviour
{
    private GameObject player;
    private GrapplingFly flyScript;

    private DragFlyToFrog fly;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        fly = null;
        flyScript = player.GetComponent<GrapplingFly>();

    }

    public void OnMouseDown()
    {
        fly = this;
        flyScript.FlyGrapple(fly); //spelaren vet då vilken fluga man grapplar
    }

    public void OnMouseUp()
    {
        fly = null;
        flyScript.StopGrapplingFly();
    }
}

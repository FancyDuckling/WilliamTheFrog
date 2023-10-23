using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPlatform : MonoBehaviour
{
    // ref till vår spelares script
    private GameObject player;
    private PlayerMovement playerScript;

    //ref till oss själva 
    private UpperPlatform upperPlatform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        upperPlatform = null;
        playerScript = player.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        upperPlatform = this;
        playerScript.Grappling(upperPlatform); //spelaren vet då vilken plattform man grapplar
    }

    public void OnMouseUp()
    {
        upperPlatform = null;
        playerScript.StopGrappling();
    }
}

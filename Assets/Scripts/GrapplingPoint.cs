using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingPoint : MonoBehaviour
{
    // ref till v�r spelares script
    private GameObject player;
    private PlayerMovement playerScript;

    //ref till oss sj�lva 
    private GrapplingPoint upperPlatform;

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
        playerScript.Grappling(upperPlatform); //spelaren vet d� vilken plattform man grapplar
    }

    public void OnMouseUp()
    {
        upperPlatform = null;
        playerScript.StopGrappling();
    }
}

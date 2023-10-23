using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingFly : MonoBehaviour
{
    //Grappling hook Fly
    private LineRenderer lineRend;
    private DistanceJoint2D distJoint;
    private DragFlyToFrog selectedFly;

    // Start is called before the first frame update
    void Start()
    {
        //Garppling hook fly 
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();

        lineRend.enabled = false;
        distJoint.enabled = false;
        selectedFly = null;
    }

    // Update is called once per frame
    void Update()
    {
        GrapplingBehaviourFly(); //fly grapple
    }

    public void FlyGrapple(DragFlyToFrog dragFlyToFrog)
    {
        selectedFly = dragFlyToFrog;
    }

    public void StopGrapplingFly()
    {
        selectedFly = null;
    }

    public void GrapplingBehaviourFly()
    {
        //om vi inte grapplar gör inget
        if (selectedFly == null)
        {
            lineRend.enabled = false;
            distJoint.enabled = false;

            return;
        }

        //om vi grapplar
        lineRend.enabled = true;
        distJoint.enabled = true;

        distJoint.connectedBody = selectedFly.GetComponent<Rigidbody2D>();
    }
}

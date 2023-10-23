using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private float xMin = -0.5f, xMax = 0.5f;
    private float timeValue = 0.0f;

    public bool isMoving = true;
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
         BackAndForth();

        }
        else
        {
         bobbing();

        }
    }

    private void BackAndForth()
    {
        float oscillationX = transform.position.x + Mathf.Cos(Time.time * 0.23f) * 0.001f;
        float oscillationY = transform.position.y + Mathf.Sin(Time.time + 0.5f) * 0.001f;
        transform.position = new Vector3(oscillationX, oscillationY, transform.position.z);
    }
    private void bobbing()
    {
        float oscillationY = transform.position.y + Mathf.Sin(Time.time +5f) * 0.0005f;
        transform.position = new Vector3(transform.position.x, oscillationY, transform.position.z);
    }


}

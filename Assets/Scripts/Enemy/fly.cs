using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer;
    public bool isMoving = true;
    public bool isBobbingBig = true;
    public bool isBobbingSmall = true;
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            BackAndForth();

        }
        else if (isBobbingBig)
        {
            BobbingBig();
        }
        else if (isBobbingSmall)
        {
            IsBobbingSmall();
        }
    }

    private void BackAndForth()
    {
        float oscillationX = transform.position.x + Mathf.Cos(Time.time * 0.25f) * 0.001f;
        float oscillationY = transform.position.y + Mathf.Sin(Time.time + 0.3f) * 0.001f;
        transform.position = new Vector3(oscillationX, oscillationY, transform.position.z);
    }
    private void BobbingBig()
    {
        float oscillationY = transform.position.y + Mathf.Sin(Time.time + 10f) * 0.0005f;
        transform.position = new Vector3(transform.position.x, oscillationY, transform.position.z);
    }

    private void IsBobbingSmall()
    {
        float oscillationY = transform.position.y + Mathf.Sin(Time.time + 10f) * 0.0001f;
        transform.position = new Vector3(transform.position.x, oscillationY, transform.position.z);
    }
}

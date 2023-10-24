using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : MonoBehaviour
{
    float randomFrequency;
    float randomAmplitude; 
    

    // Update is called once per frame
    void Update()
    {
        randomAmplitude = Random.Range(0.001f, 0.1f);
        randomAmplitude = Random.Range(0.001f, 0.1f);
        float fly3oscX = transform.position.x + Mathf.Cos(Time.time * randomFrequency) * randomAmplitude;
        float fly3oscY = transform.position.y + Mathf.Sin(Time.time * randomFrequency) * randomAmplitude;
         transform.position = new Vector3(fly3oscX, fly3oscY,transform.position.z);   
    }
}

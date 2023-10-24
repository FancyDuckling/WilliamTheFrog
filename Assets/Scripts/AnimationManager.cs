using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator frogStateAnimation;

    private void Start()
    {
        frogStateAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check for user input and trigger the appropriate animations
        if (Input.GetKeyDown(KeyCode.Space))
        {
            frogStateAnimation.SetTrigger("Jump");
        }
        else if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            frogStateAnimation.SetTrigger("OpenMouth");
        }
        else
        {
            frogStateAnimation.SetTrigger("Idle"); // Trigger IdleFrog animation
        }
    }
}

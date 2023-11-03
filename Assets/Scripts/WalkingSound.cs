using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
   
    public AudioClip walkSound;
    public AudioClip jumpSound;
    

    private AudioSource audioSource;
    private bool isWalking;
    private bool isJumping;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            if (!isWalking)
            {
                PlaySound(walkSound);
                audioSource.loop = true;
                isWalking = true;
            }
        }

        else
        {
            isWalking = false;
            audioSource.loop = false;
            PauseSound(walkSound);

        }

        if (!isJumping)
        {
            
            PlaySound(jumpSound); 
            isJumping = true;
        }
        
        else
        {
            isJumping= false;
        }

    }

    private void PlaySound(AudioClip soundClip)
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }

    private void PauseSound(AudioClip soundClip)
    {
        audioSource.Pause();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip grapplingSound;
    public AudioClip walkSound;

    private AudioSource audioSource;
    private bool isWalking;

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
                isWalking = true;
            }
        }

        else if (Input.GetButtonDown("Jump"))
        {
            PlaySound(jumpSound);
        }

        else
        {
            isWalking = false;
            audioSource.Stop();
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
}

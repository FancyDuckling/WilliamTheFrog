using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public string winSceneName = "Win";

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object that entered the trigger is the player (or any object you want to trigger the win condition).
        
            // Load the win scene.
            SceneManager.LoadScene(winSceneName);
       
    }
}

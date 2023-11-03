using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 3;
    public SpriteRenderer[] heartImage;
    public bool canTakeDamage = true;
    public Transform respawnPoint;

    private void Start()
    {
        
      UpdateHealth();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            FrogTakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
             FrogTakeDamage();
        }
    }

    void FrogTakeDamage()
    {
        StartCoroutine("InvincibilityTime");
        StartCoroutine("FreeazeFrames");
        health--;
        UpdateHealth();
        Invoke("RespawnPlayer", 0.3f);
      
        if (health == 0)
        {
            SceneManager.LoadScene("Game Over");

        }

    }

    void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
    }
    
    public void UpdateHealth()
    {
        for (int i = 0; i < heartImage.Length; i++)
        {
            if(i<health)
            {
                heartImage[i].enabled = true;
            }
            else
            {
                heartImage[i].enabled=false;
            }
        }
    }

    IEnumerator InvincibilityTime()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
    }

    IEnumerator FreeazeFrames()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1;

    }

}

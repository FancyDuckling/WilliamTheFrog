using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 3;
    public Image[] heartImage;
    public bool canTakeDamage = true;

    private void Start()
    {
       // UpdateHealth();
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
        //if(other.gameObject.CompareTag("Enemy"))
        //{
        //    FrogTakeDamage();
        //}
    }

    void FrogTakeDamage()
    {
        StartCoroutine("InvincibilityTime");
        StartCoroutine("FreeazeFrames");
        health--;
        UpdateHealth();
      
        if (health == 0)
        {
            Debug.Log("you are dead");
        }

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

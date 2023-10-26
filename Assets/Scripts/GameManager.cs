using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int scorePlayer;
    public int scorePlayer2;
    
   public TextMeshProUGUI flyScoreText;
    public TextMeshProUGUI wurmScoreText;


    // Start is called before the first frame update
    void Start()
    {
        // Find the TextMeshProUGUI object by name (adjust the name as needed)
        flyScoreText = GameObject.Find("FlyScoreText").GetComponent<TextMeshProUGUI>();
        wurmScoreText = GameObject.Find("WurmScoreText").GetComponent<TextMeshProUGUI>();
        

        // Update the score display initially
        SetScore(scorePlayer);
        SetScore(scorePlayer2);
        
    }

    public void AddPoint()
    { 
        scorePlayer+=2;
        SetScore(scorePlayer);
    }

    public void AddPoint2()
    {
        scorePlayer2++;
        SetScore2(scorePlayer2);
    }
 
    

    public void SetScore(int value)
    {
        flyScoreText.text = value.ToString();
        
        
    }

    public void SetScore2(int value)
    {
        wurmScoreText.text = value.ToString();
    }



}

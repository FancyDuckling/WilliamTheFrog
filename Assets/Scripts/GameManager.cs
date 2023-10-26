using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int scorePlayer;
    TextMeshProUGUI flyScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Find the TextMeshProUGUI object by name (adjust the name as needed)
        flyScoreText = GameObject.Find("FlyScoreText").GetComponent<TextMeshProUGUI>();

        // Update the score display initially
        SetScore(scorePlayer);
    }

    public void AddPoint()
    {
            scorePlayer+=2;
            SetScore(scorePlayer);
    }

    public void SetScore(int value)
    {
        flyScoreText.text = value.ToString();
    }

  
}

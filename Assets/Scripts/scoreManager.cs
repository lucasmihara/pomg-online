using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public int scorePlayerOne;
    public int scorePlayerTwo;

    public GameObject playerOneRef;
    public GameObject playerTwoRef;

    // Start is called before the first frame update
    void Start()
    {
        resetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(bool player)
    {
        if (player == false)
        {
            scorePlayerOne++;
            playerOneRef.GetComponent<TMP_Text>().text = scorePlayerOne.ToString("00");
        }
        else
        {
            scorePlayerTwo++;
            playerTwoRef.GetComponent<TMP_Text>().text = scorePlayerTwo.ToString("00");
        }
    }

    public void resetScore()
    {
        scorePlayerOne = 0;
        scorePlayerTwo = 0;
    }
}

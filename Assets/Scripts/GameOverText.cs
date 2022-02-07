using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverText : MonoBehaviour
{

    public Text yourScoreText; //set a text variable to show your score
    public Text bestScoreText; //set a text variable to show your best score

    void Start()
    {
        
    }


    void Update()
    {
        yourScoreText.text = "your score: " + GameManager.score; //show your score in yourScoreText
        bestScoreText.text = "Best score: " + GameManager.bestScore; //show your score in bestScoreText
    }
}

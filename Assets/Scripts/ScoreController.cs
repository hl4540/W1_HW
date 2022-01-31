using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text scoreText; //set a text variable to show the score
    private int score; //set an integer variable to count the score


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score:" + score; //update the scoreText
    }


    void OnTriggerEnter(Collider target) //when the trigger hit...
    {
        if (target.tag == "poop"){ //the object with "poop" tag,
            score --; //score reduced for 1
        } else { //if it hit the object other than that,
            score ++; //score increase for 1
        }

        Destroy(target.gameObject);//destroy any object that hit the trigger

    }

}

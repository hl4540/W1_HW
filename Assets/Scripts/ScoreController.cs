using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text scoreText; //set a text variable to show the score
    public Text sceneText; //set a text variable to show the level
    public Text poopNumber; //set a text to show the number of poop that you gain


    void Start()
    {
        
    }


    void Update()
    {
        scoreText.text = "score:" + GameManager.score; //update the scoreText
        poopNumber.text = "poop:" + GameManager.nPoop; //update the poopNumber

        if (GameManager.isLevel1 == true) //if you are in Level1,
        {
            sceneText.text = "level 1"; //show Level1 in the sceneText
        }else{ //if not,
            sceneText.text = "level 2"; //show that you are in Level2
        }
    }


    void OnTriggerEnter(Collider target) //when the trigger hit...
    {
        if (target.tag == "poop"){ //the object with "poop" tag,
            GameManager.score --; //score reduced for 1
            GameManager.nPoop ++;
        } else { //if it hit the object other than that,
            GameManager.score ++; //score increase for 1
        }

        Destroy(target.gameObject);//destroy any object that hit the trigger

    }

}

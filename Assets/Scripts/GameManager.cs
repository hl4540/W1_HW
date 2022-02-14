using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static float score; 
    //make the score a public static variable so that other script can access and change it,
    //and can be shared in various instances
    public static float bestScore = 0f;
    //make the best score a public static variable so that ...
    public static int nPoop;
    //make the number of poop a public static so that ...
    public static bool isMenu = true;
    //set a boolean variable to check if the Menu scene is loaded
    public static bool isLevel1 = false; //set a boolean to check if the level1 scene is loaded
    //private bool isLevel2 = false;
    private bool isGameOver = false;
    //set a boolean to check if the GameOver scene is loaded

    public AudioSource music;
    //set a public variable to assing a music

    


    //---------singleton ↓ -----------

    private static GameManager instance;
    //create a variable called "instance". the variable type is a class, called GameManager
    
    public static GameManager GetInstance(){
        return instance;
    } //create a function that would get and return the instance that GameManager script is assigned

    private void Awake() //this would happen in very begining
    {
        if(instance != null && instance != this) // when there IS/ARE GameManager instance(s) existing, and it's not this one
        {
            Destroy(this); //detroy this instance
        }
        else //otherwhise
        {
            instance = this; //the only instance would be this one
            DontDestroyOnLoad(gameObject); //don't destroy this GameManager instance when other Scenes are Loaded
        }
    }
    //---------------------------------

    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        //set the volume of the music as the value that set in the PlayerPrefs
        //Debug.Log(PlayerPrefs.GetFloat("MusicVolume"));
    }

    void Update()
    {

        if (Input.GetKeyDown("space") && (isMenu == true || isGameOver == true))
        //when Menu Scene or GameOver Scene is loaded, and you press the spacebar
        {
            Destroy(gameObject);
            //destroy the GameManager
            SceneManager.LoadScene("Preference");
            //Load Preference Scene
            isMenu = false;
            //set isMenu as false cuz it's gonna be Preference Scene
            
        }

        if (Input.GetMouseButton(0) && (isMenu == true || isGameOver == true)) 
        //when Menu Scene or GameOver Scene is loaded, and you press the left mouse button
        {
            score = 0; //initialize the score
            nPoop = 0; //initialize the poop number
            isMenu = false; //set isMenu to false cuz the Level1 Scene are gonna be loaded
            isGameOver = false; //set isGameOver to false cuz the Level1 Scene are gonna be loaded
            SceneManager.LoadScene("Game1"); //load Level1
            isLevel1 = true; //set isLevel1 as true cuz it's gonna be loaded
        }
        
        if (score >= 10 && isLevel1 == true) //when you are in the level1, and your score is more than or equals to 10
        {
            SceneManager.LoadScene("Game3"); //go to level2 
            //(I named the scene Game3, because there was something going wrong with Game2, and for somereason I couldn't fix and save it...)
            isLevel1 = false; //turn off the isLevel1 cuz it's gonna be Level2
        }

        if (nPoop >= 3 && isGameOver ==false) //when you are not GameOver yet, and you get 3 or more than 3 poops,
        {
            SceneManager.LoadScene("GameOver"); // load GameOver Scene,
            //Debug.Log("GameOver");
            isGameOver = true; //set isGameOver as true
            

            if (score > bestScore && isGameOver == true) //when you are in the GameOver Scene, and your score this time is larger than the bestscore
            {
                bestScore = score; //it's gonna be your new record!
            }
        }
    }
}



//I think there would be more logically simple ways to do this - Scene Loading / best score saving - feature
//I may figure it ould later on ... I tried my best this time ;(
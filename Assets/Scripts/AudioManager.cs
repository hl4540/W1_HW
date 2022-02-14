using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music; //set a public audio variable to assing a music

    public Slider musicVolume; //set a slider variable for the volume of the music

    // Start is called before the first frame update
    void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume"); 
        //get the value from PlayerPrefs using the key "MusicVolume" and assign it as the volume of the music
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = musicVolume.value;
        //read the value of the slider and change the volume of the music
    }


    public void VolumePrefs()//make a function that save the PalyerPrefs value (PUT THIS INTO THE BUTTON)
    {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
        //save the changed value of the music volume into the PlayerPref
    }

    // void PlayMusic()
    // {
    //     StartCoroutine("FadeSound");
    // }

    // IEnumerator FadeSound()
    // {
    //     while(music.volume > 0.01f)
    //     {
    //         music.volume -= Time.deltaTime / 1.0f;
    //         yield return null;
    //     }
    // }
}

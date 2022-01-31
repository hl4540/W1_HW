using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    [SerializeField] GameObject[] fruitPrefab; // create an array named fruitPrefab to store GameObject variable
    [SerializeField] float secondSpawn = 1f; //set a float variable for the spawn time
    [SerializeField] float minX; //set a float variable for the minimam x position to spawns the object
    [SerializeField] float maxX; //set a float variable fot the maximum x position to spawns the object

    void Start()
    {
        StartCoroutine(FruitSpawn()); //call FruitSpawn coroutine
    }

    IEnumerator FruitSpawn()
    {
        while(true) //while FruitSpawn is called, repeat the following function:
        {
            float wantedX = Random.Range(minX, maxX); // set a float variable to randomize the horizontal spawn position
            var position = new Vector3(wantedX, transform.position.y);// set a variable for the spawn position
            GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], //randomly call a object from fruitPrefab array
                                                position, //at the random x position that set above
                                                Quaternion.identity); //with no rotation
            yield return new WaitForSeconds(secondSpawn); //repeat this coroutine after few seconds
            Destroy(gameObject, 3f); //destroy the object in 5seconds

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float moveSpeed = 10; //set a float variable for the moovement speed

    void Update()
    {
        float movement = Input.GetAxis("Horizontal"); //set a float variable to measure the horizontal input
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed; //calculate the new position for the object
    }
}

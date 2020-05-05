using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //access the rigidBody of the rocket
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }


    private void ProcessInput()
    {


        if (Input.GetKey(KeyCode.Space))  //can thrust while rotating
        {
            //add force to the rigidbody relative to its coordinate system
            //will add force that is always in the direction that the ship is facing
            // the function want a vector3
            //3 floating point position numbers bundeled together
            //si masse trop lourde ca décollera pas si pas assez de force
            rigidBody.AddRelativeForce(Vector3.up);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (audioData.isPlaying)
            {
                audioData.Stop();
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //transform component is on every game object so unity give us direct acces to it
            transform.Rotate(Vector3.forward); //forward = z axis
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

    }
}

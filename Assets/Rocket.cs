using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField]float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidBody;
    AudioSource audioData;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //Access the rigidBody of the rocket
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
      
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioData.isPlaying) // so it doesn't layer
            {
                audioData.Play();
            }
        }
        else
        {
            audioData.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime; //make it frame speed independant

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }
}

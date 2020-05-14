using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f; //oscillation period, time it takes to complete on full cycle

    //[Range(0, 1)]
    //[SerializeField]
    float movementFactor; //0 for moved, 1 for fully moved

    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //empeche de diviser par 0
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        //grows continually from zero
        float cycles = Time.time / period; //if the game time is 1 sec we will have make half a cycle

        //to get all around the circle you need 6.28 radians (tau radians)
        const float tau = Mathf.PI * 2f; //(1 tau = 2 pi);

        //if we want full cycle we put in two pi. if we want half cycle we put in PI.
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to +1

        //variera entre -1 et +1
        print(rawSinWave);

        movementFactor = rawSinWave / 2f + 0.5f; //ca va donner un nb entre -0.5 et 0.5
        //mais nous on veut un nb entre 0 et 1 donc on rajoute 0.5f

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}

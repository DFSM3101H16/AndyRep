using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Launch : MonoBehaviour
{
    public LaunchTimer timer;  //

    BoxCollider myCollider;
    public Vector3 velocity;
    public float y; //Altitude of player
    public float y0; //Initial altitude of player
    public float vy0; //Initial vertical velocity of player
    public float x;   // horizontal location of player
    public float x0;  // initial horizontal location of player
    public float vx0;  //initial horizontal velocity of player
    public float time;
    public float gravity;
    public float testTime;
    public float testVel;
    public float fixedTime;
    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        velocity = new Vector3(x, y, 0);
        timer = GetComponent<LaunchTimer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updatePosition();
        updateCollision();
    }


    void updatePosition()
    {
        /*
        float timeIncrement = 0.02f;
        time += timeIncrement;
        */
        //time = timer.currentTime;
        x = x0 + vx0 * Time.fixedDeltaTime;
        y = y0 + vy0 * Time.fixedDeltaTime + 0.5f * gravity * Time.fixedDeltaTime * Time.fixedDeltaTime;

        velocity = new Vector3(x, y, 0);

        transform.position += (velocity * Time.fixedDeltaTime);
    }

    void updateCollision()
    {
        /*
        if (transform.position.y < 0)
        {
            y = transform.position.y;
            x = transform.position.x;
            gravity = 0;
       //     x0 = 0;
       //     y0 = 0;
            vx0 = 0;
            vy0 = 0;
            timer.Finnished();
        }
        */
        if (y <= 1.4)
        {
            testTime = time;
            testVel = y;
            // Debug.Break();
        }
    }
}

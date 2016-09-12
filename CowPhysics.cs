using UnityEngine;
using System.Collections;

public class CowPhysics : MonoBehaviour {
    //STUFF
    public LaunchTimer timer;
    BoxCollider cowCollider;
    //VECTORS
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 iVel;
    public Vector3 gravity;
    public Vector3 force;
    public Vector3 netForce;

    //VALUES
    public float vy0; //Initial vertical velocity in m/s
    public float vx0; //Initial horisontal velocity m/s
    public float mass; //Mass of object in kg
    public float angle; //in degrees
    public float vel; //inital velocity m/s at hypotemus

    //Friction
    public float my;

    //EndValues
    public float verticalDisplacement; //In meters
    public float horizontalDisplacement; //In meters

    public int gameState;

	// Use this for initialization
	void Start () {
        cowCollider = GetComponent<BoxCollider>();
        acceleration = new Vector3(0, 0, 0);
        velocity = new Vector3(0, 0, 0);
        gravity = new Vector3(0, -9.81f, 0);
        netForce = new Vector3(0, 0, 0);
        iVel = new Vector3(0, 0, 0);
        timer = GetComponent<LaunchTimer>();
        GetComponent<Renderer>().material.color = new Color(255f, 0, 0); //C sharp
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        checkInput();

        if (gameState == 1)
        {
            timer.Begin();          
            updateForce();
            updateAcceleration();
            updateVelocity();
            updatePosition();
            updateCollision();
        }
        if(gameState == 0)
        {
            timer.Finnished();
        }
	
	}
    void checkInput()
    {
        if (gameState == 2)
        {
            if (Input.GetKeyDown("a"))
            {
                angle -= 0.5f;
            }
            if (Input.GetKeyDown("d"))
            {
                angle += 0.5f;
            }
            if (Input.GetKeyDown("w"))
            {
                vel += 1;
            }
            if (Input.GetKeyDown("s"))
            {
                vel -= 1;
            }
            if (Input.GetKeyDown("space"))
            {
                calculateVelocity();
                gameState = 1;
                timer.startTime = Time.time;
            }
        }
    }
    void updateCollision()
    {
        if(transform.position.y < -100)
        {
            velocity = new Vector3(0, 0, velocity.z);
            force = new Vector3(0,9.81f,0);
            timer.Finnished();
        }
    }


    void updateForce()
    {
        netForce = ((gravity * mass) + force);
        force *= 0;
    }

    void updateAcceleration()
    {
        acceleration = (netForce / mass);
    }
    void updateVelocity()
    {
        velocity += (acceleration) * Time.fixedDeltaTime;
    }

    void updatePosition()
    {
        transform.position += (velocity * Time.fixedDeltaTime);
        verticalDisplacement = transform.position.y;
        horizontalDisplacement = transform.position.x;
    }

    void calculateVelocity()
    {
        float radAngle = angle * Mathf.Deg2Rad;
        vy0 = Mathf.Sin(radAngle) * vel;
        vx0 = Mathf.Cos(radAngle) * vel;
        iVel = new Vector3(vx0, vy0, 0);
        velocity = (iVel);
    }
}

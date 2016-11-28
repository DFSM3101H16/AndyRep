using System;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private PlayerStats plstats;
    //LOOKING WITH CAMERA
    public float cameraSensitivity = 90;
    public float normalMoveSpeed = 10;
    public float fastMoveFactor = 2;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    //PLAYER MOVEMENT
    Transform playerPos;
    public Vector3 currentPosition;
    public Vector3 currentVelocity;

    Vector3 newPosition = Vector3.zero;
    Vector3 newVelocity = Vector3.zero;

    //Max/Min Value for Y while on the ground
    private float minY = 1.5f;
    private float maxY = 1.8f;

    //PLAYER MOVEMENT STATUS BOOLS
    bool grounded;

    bool standing;

    public bool stopped;

    //Parachuting
    //public GameObject openParachute;
    public bool parachute;


    void Start()
    {
        Cursor.visible = false;
        playerPos = GetComponent<Transform>();
        plstats = GetComponent<PlayerStats>();
    }

    void Awake()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        //LOOKING WITH CAMERA
        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

    }

    void FixedUpdate()
    {
        if (!grounded)
        {
            if (Input.GetKey(KeyCode.E))
            {
                parachute = true;
            }
            MovePlayer();
        }
        if(grounded && !standing)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            parachute = false;
            StandUp();
        }
        else if(grounded && standing)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float h = Time.fixedDeltaTime; //Timestep
        if (parachute && !grounded)
        {
            IntegrationMethods.PlayerHeuns(parachute,h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        }
        else if (!parachute && !grounded)
        {
            IntegrationMethods.PlayerHeuns(parachute,h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        }
        if(grounded)
        {
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                newPosition += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
                newPosition += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
            }
            else
            {
                newPosition += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
                newPosition += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
            }

            if (Input.GetKey(KeyCode.Space)) { Jump(); }
        }

        CheckHit();

        currentPosition = newPosition;
        currentVelocity = newVelocity;

        transform.position = currentPosition;

    }

    void CheckHit()
    {
        Vector3 movingDirection = (newPosition - currentPosition).normalized;
        float playerDistance = Vector3.Distance(newPosition, currentPosition);

        RaycastHit hit;
        //if(Physics.Raycast(currentPosition, movingDirection, out hit, playerDistance))
        if (Physics.SphereCast(currentPosition, 0.5f,movingDirection, out hit, playerDistance))
        {
            if(hit.collider.CompareTag("Ground"))
            {
                Debug.Log("TOUCHDOWN!");
                if(!grounded)
                    OnGround();
            }
            if(hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Do not run into walls!");
                newPosition = currentPosition;
            }
            if(hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Looking for love?");
            }
            if(hit.collider.CompareTag("Rocket"))
            {
                Debug.Log("Sabotaged Rocket!");
                hit.collider.GetComponent<RocketEngine>().activate = true;
            }
        }
    }

    void OnGround()
    {
        if(currentVelocity.y < -15f)
        {
            Debug.Log("Take damage!");
            plstats.dead = true;
        }
        grounded = true;
    }

    void Jump()
    {
        /*
        Debug.Log("JUMPING!");
        grounded = false;
        MovePlayer();
        */
    }

    void StandUp()
    {
        standing = true;
    }

}



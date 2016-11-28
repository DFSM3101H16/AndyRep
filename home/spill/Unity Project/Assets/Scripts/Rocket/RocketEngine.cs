using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RigidRocket))]
public class RocketEngine : MonoBehaviour {

    public float fuelMass;            //[kg]
    public float maxThrust;           //kN [kg m s^-2]

    [Range (0,1f)]
    public float thrustPercent;       //[none]

    public Vector3 thrustUnitVector;  //[none]
    public Vector3 gravity;

    private RigidRocket rigidRocket;
    private float currentThrust;  // N

    public bool sabotaged;
    public bool activate;

	// Use this for initialization
	void Start ()
    {
        rigidRocket = GetComponent<RigidRocket>();
        rigidRocket.mass += fuelMass;
        gravity = new Vector3(0f, -9.81f, 0f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (activate && !sabotaged)
        {
            if (fuelMass > FuelThisUpdate())
            {
                fuelMass -= FuelThisUpdate();
                rigidRocket.mass -= FuelThisUpdate();
                rigidRocket.AddForce(thrustUnitVector);
                ExertForce();
            }
            else
            {
                Debug.LogWarning("OUT OF ROCKET FUEL");

            }
        }
        else if (activate && sabotaged)
        {
            Debug.Log("YOU JUST WON THE GAME!");
            if (fuelMass > FuelThisUpdate())
            {
                fuelMass -= FuelThisUpdate();
                rigidRocket.mass -= FuelThisUpdate();
                rigidRocket.AddForce(thrustUnitVector);
                ExertForce();
            }
            else
            {
                Debug.LogWarning("OUT OF ROCKET FUEL");

            }
        }
	}

    float FuelThisUpdate()
    {
        float exhaustMassFlow;
        float effectiveExhaustVelocity;

        effectiveExhaustVelocity = 4462f;       //[m s^-1] liquid H O
            // thrust = massFlow * exhaustVelocity
            //massFlow = thrust / exhaustVelocity

        exhaustMassFlow = currentThrust / effectiveExhaustVelocity; 

        return exhaustMassFlow * Time.deltaTime;   // [kg]
    }

    void ExertForce()
    {
        currentThrust = thrustPercent * maxThrust * 1000f;
        Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; // N
        rigidRocket.AddForce(thrustVector);
        rigidRocket.AddForce(gravity);
        if(transform.position.y <= 200f)
        {
            Debug.Log("END GAME!");
            if(sabotaged)
            {
                Debug.Log("Really won the game!");
            }
            else if(!sabotaged)
            {
                Debug.Log("You fail!");
            }
        }
    }
}

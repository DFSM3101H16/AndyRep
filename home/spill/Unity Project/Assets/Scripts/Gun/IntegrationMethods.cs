using UnityEngine;
using System.Collections;

public class IntegrationMethods : MonoBehaviour {
    //USED INSIDE HEUNS METHOD FOR PREDICTION
    public static void EulerForward(
        float h,
        Vector3 currentPosition,
        Vector3 currentVelocity,
        out Vector3 newPosition,
        out Vector3 newVelocity
        )
    {
        Vector3 accelerationFactor = new Vector3(0f, -9.81f, 0f);
        accelerationFactor += BulletPhysics.CalculateDrag(currentVelocity);
        Vector3 velocityFactor = currentVelocity;
        newPosition = currentPosition + h * velocityFactor;
        newVelocity = currentVelocity + h * accelerationFactor;
    }
    //HEUNS METHOD USED FOR CORRECTION OF EULER IN A PREDICTION/CORRECTION.
    public static void Heuns(
        float h,
        Vector3 currentPosition,
        Vector3 currentVelocity,
        out Vector3 newPosition,
        out Vector3 newVelocity)
    {
        Vector3 accelerationFactorEuler = new Vector3(0f, -9.81f, 0f);
        Vector3 accelerationFactorHeun = new Vector3(0f, -9.81f, 0f);
        Vector3 velocityFactor = currentVelocity;
        Vector3 pos_E = currentPosition + h * velocityFactor;
        accelerationFactorEuler += BulletPhysics.CalculateDrag(currentVelocity);
        Vector3 vel_E = currentVelocity + h * accelerationFactorEuler;
        Vector3 pos_H = currentPosition + h * 0.5f * (velocityFactor + vel_E);
        accelerationFactorHeun += BulletPhysics.CalculateDrag(vel_E);
        Vector3 vel_H = currentVelocity + h * 0.5f * (accelerationFactorEuler + accelerationFactorHeun);
        newPosition = pos_H;
        newVelocity = vel_H;
    }

    //THIS IS ONLY USED FOR THE PARADROP, TEMP SOLUTION NEEDED A BOOL FOR THE PARACHUTE TO BE DETECTED!
    public static void PlayerHeuns(bool parachute, float h,
        Vector3 currentPosition,
        Vector3 currentVelocity,
        out Vector3 newPosition,
        out Vector3 newVelocity)
    {
        Vector3 accelerationFactorEuler = new Vector3(0f, -9.81f, 0f);
        Vector3 accelerationFactorHeun = new Vector3(0f, -9.81f, 0f);
        Vector3 velocityFactor = currentVelocity;
        float area = 1.5f;
        Vector3 pos_E = currentPosition + h * velocityFactor;
        if (!parachute)
            accelerationFactorEuler += PlayerPhysics.CalculateDrag(currentVelocity);
        else if (parachute)
        {      
            accelerationFactorEuler += PlayerPhysics.CalculateParachuteDrag(currentVelocity, area);
        }
        Vector3 vel_E = currentVelocity + h * accelerationFactorEuler;
        Vector3 pos_H = currentPosition + h * 0.5f * (velocityFactor + vel_E);
        if (!parachute)
            accelerationFactorHeun += PlayerPhysics.CalculateDrag(vel_E);
        else if (parachute)
        {
            Debug.Log(area);
            accelerationFactorHeun += PlayerPhysics.CalculateParachuteDrag(vel_E, area);
        }
        Vector3 vel_H = currentVelocity + h * 0.5f * (accelerationFactorEuler + accelerationFactorHeun);
        newPosition = pos_H;
        newVelocity = vel_H;
        }
}

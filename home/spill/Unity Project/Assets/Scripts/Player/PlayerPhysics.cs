using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

    public static Vector3 CalculateDrag(Vector3 velocityVec)
    {
        float m = 100f; //kg
        float C_d = 0.47f;
        float A = Mathf.PI * 0.5f * 0.5f;
        float rho = 1.225f; //kg/m3

        float k = 0.5f * C_d * rho * A;
        float vSqr = velocityVec.sqrMagnitude;

        float aDrag = (k * vSqr) / m;

        Vector3 dragVec = aDrag * velocityVec.normalized * -1f;
        return dragVec;
    }

    public static Vector3 CalculateParachuteDrag(Vector3 velocityVec, float area)
    {
        float m = 100f; //kg
        float C_d = 1.75f;
        float A = Mathf.PI * area * area;
        float rho = 1.225f; //kg/m3

        float k = 0.5f * C_d * rho * A;
        float vSqr = velocityVec.sqrMagnitude;

        float aDrag = (k * vSqr) / m;

        Vector3 dragVec = aDrag * velocityVec.normalized * -1f;
        return dragVec;
    }

}

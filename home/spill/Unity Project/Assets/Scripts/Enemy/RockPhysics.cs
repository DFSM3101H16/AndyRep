using UnityEngine;
using System.Collections;

public class RockPhysics : MonoBehaviour {
    public Vector3 CalculateDrag(Vector3 velocityVec)
    {
        //F_drag = k * v^2 = m * a
        //K = 0.5 * C_d * rho * A
        float m = 2.0f;  //kg;
        float C_d = 0.5f; //Sphere
        float A = 4 * Mathf.PI * 0.5f * 0.5f; //m^2
        float rho = 1.225f; //kg/m3
        float k = 0.5f * C_d * rho * A;
        float vSqr = velocityVec.sqrMagnitude;
        float aDrag = (k * vSqr) / m;
        Vector3 dragVec = aDrag * velocityVec.normalized * 1f;
        return dragVec;
    }
}

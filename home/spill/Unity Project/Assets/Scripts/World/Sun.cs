using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckPos();
        transform.RotateAround(Vector3.zero, Vector3.right, 0.5f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
    void CheckPos()
    {
        if(transform.position.y <= 180f)
        {
            GameObject.FindGameObjectWithTag("Rocket").GetComponent<RocketEngine>().activate = true;
        }
    }
}

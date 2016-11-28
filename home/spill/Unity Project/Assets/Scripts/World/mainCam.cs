using UnityEngine;
using System.Collections;

public class mainCam : MonoBehaviour {

    public Transform targetpos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void FixedUpdate()
    {
        //transform.LookAt(targetpos.position);

        transform.LookAt(new Vector3(targetpos.position.x, 0f, targetpos.position.z));
    }
}

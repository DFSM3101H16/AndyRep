using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour{

    public Vector3 decend;
	// Use this for initialization
	void Start () {
        Vector3 dencend = new Vector3(0f, 1f, 0f);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y > 130f)
        {
                decend.y -= 5f;
                transform.position += decend * Time.fixedDeltaTime;
        }
        else if(transform.position.y < 130f)
        {
            decend = new Vector3(0f, 0f, 0f);

        }

	
	}
}

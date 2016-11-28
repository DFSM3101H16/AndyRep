using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public bool dead;
    public int health = 10;
    private Transform PlayerTransform;

	// Use this for initialization
	void Start () {
        PlayerTransform = GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(health == 0)
        {
            dead = true;            
        }
	
	}

    public void TakeDamage()
    {
        health--;
    }
}

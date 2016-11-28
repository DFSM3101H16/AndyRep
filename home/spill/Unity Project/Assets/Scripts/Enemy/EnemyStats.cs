using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public int health = 1;
    private Transform EnemyTransform;

    public bool dead;
    public bool throwingRock;
    public bool moving;

    EnemyControl enControl;
    EnemyAI enemyAI;

	// Use this for initialization
	void Start () {
        health = 1;
        EnemyTransform = GetComponent<Transform>();
        enControl = GetComponent<EnemyControl>();

        if(GetComponent<EnemyAI>())
        {
            enemyAI = GetComponent<EnemyAI>();
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!dead)
        {
            if(health <= 0)
            {
                health = 0;
                dead = true;
                enemyAI.CurState = EnemyAI.State.DEAD;
                KillCharacter();
            }
            
        }	
	}

    public void StopMoving()
    {
        enControl.moving = false;
    }

    public void StartMoving()
    {
        enControl.moving = true;
    }
    public void DoDamage()
    {
        health--;
    }

    public void KillCharacter()
    {
        dead = true;
        
    }


}

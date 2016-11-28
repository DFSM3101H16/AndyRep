using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    public Animator anim;
    public EnemyStats enStats;
    public EnemyWeapon enWeapon;

    public bool moving;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enStats = GetComponent<EnemyStats>();
        enWeapon = GetComponentInChildren<EnemyWeapon>();
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleAnimation();
        HandleDying();
        HandleThrowing();	
	}


    void HandleThrowing()
    {
        if (enStats.throwingRock)
        {
            anim.SetTrigger("Throw");
            enWeapon.DoThrow();
            enStats.throwingRock = false;
        }
    }

    void HandleAnimation()
    {
        if (moving)
        {
            anim.SetFloat("Forward", 1.0f, 0.4f, Time.deltaTime);
        }
        if (!moving)
        {
            anim.SetFloat("Forward", 0.0f, 0.4f, Time.deltaTime);
        }
    }

    void HandleDying()
    {
        if (enStats.dead)
        {
            anim.SetTrigger("Die");
        }
    }

}

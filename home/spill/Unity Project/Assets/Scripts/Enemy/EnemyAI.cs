using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    /*
    public PlayerStats player;
    public EnemyControl enControl;
    */
    public EnemyStats enStats;
    
    public enum State
    {
        LOOKFOR,
        GOTO,
        ATTACK,
        DEAD,
    }

    public State CurState;

    public float Speed = 0.5f;
    public float GoToDistance = 13f;
    public float AttackDistance = 0.5f;
    public float AttackTimer = 2f;
    public Transform Target;
    public string PlayerTag = "Player";
    private float curTime;
    private PlayerStats PlayerScript;



	IEnumerator Start () {
        Target = GameObject.FindGameObjectWithTag(PlayerTag).transform;
        curTime = AttackTimer;
        if(Target != null)
        {
            PlayerScript = Target.GetComponent<PlayerStats>();
        }

        while(true)
        {
            switch(CurState)
            {
                case State.LOOKFOR:
                    LookFor();
                    break;
                case State.GOTO:
                    GoTo();
                    break;
                case State.ATTACK:
                    Attack();
                    break;
                case State.DEAD:
                    Die();
                    break;
            }
            yield return 0;
        }	
	}

    void LookFor()
    {
        if(Vector3.Distance(Target.position, transform.position) < GoToDistance)
        {
            CurState = State.GOTO;
        }
    }
    void GoTo()
    {
        transform.LookAt(Target);
        enStats.StartMoving();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit Buddy;
        if(Physics.Raycast(transform.position, fwd, out Buddy))
        {
            
            if(Buddy.transform.tag != PlayerTag)
            {
                CurState = State.LOOKFOR;
                enStats.StopMoving();
                return;
            }
        }


        if (Vector3.Distance(Target.position,transform.position) > AttackDistance)
        {
            Mathf.Clamp(transform.position.z, 1f, 1.5f);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        else
        {
            CurState = State.ATTACK;
        }
    }
    void Attack()
    {
        transform.LookAt(Target);
        curTime = curTime - Time.deltaTime;

        if(curTime < 0)
        {
            enStats.throwingRock = true;
            curTime = AttackTimer;

        }

        if(Vector3.Distance(Target.position, transform.position) > AttackDistance)
        {
            CurState = State.GOTO;
        }
    }

    void Die()
    {


    }

}

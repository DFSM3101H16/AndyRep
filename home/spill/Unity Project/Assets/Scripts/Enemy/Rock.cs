using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

    public Vector3 currentPosition;
    public Vector3 currentVelocity;

    Vector3 newPosition = Vector3.zero;
    Vector3 newVelocity = Vector3.zero;

    void Awake()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        DestroyRock();
    }

    void FixedUpdate()
    {
        MoveRock();
    }

    void CheckHit()
    {
        Vector3 fireDirection = (newPosition - currentPosition).normalized;
        float fireDistance = Vector3.Distance(newPosition, currentPosition);
        RaycastHit hit;
        if(Physics.Raycast(currentPosition, fireDirection, out hit, fireDistance))
        {
            if(hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit Player!");
                Destroy(gameObject);                
            }

            if(hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Enemy Hit Ground");

                Destroy(gameObject);

//                GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<EnemyWeapon>().AddMarker(hit.point);
            }

            if(hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Enemy Hit Wall");

                Destroy(gameObject);

                //GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<EnemyWeapon>().AddMarker(hit.point);
            }

            if(hit.collider.CompareTag("Player"))
            {
                Debug.Log("Enemy Hit Player");
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().TakeDamage();
            }
        }

        
    }

    void MoveRock()
    {
        float h = Time.fixedDeltaTime;
        IntegrationMethods.Heuns(h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        CheckHit();
        currentPosition = newPosition;
        currentVelocity = newVelocity;
        transform.position = currentPosition;
    }

    void DestroyRock()
    {
        if(transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }


}

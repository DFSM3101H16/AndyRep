using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

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
        DestroyBullet();
    }

    void FixedUpdate()
    {
        MoveBullet();
    }

    void CheckHit()
    {
        Vector3 fireDirection = (newPosition - currentPosition).normalized;
        float fireDistance = Vector3.Distance(newPosition, currentPosition);

        RaycastHit hit;
        if(Physics.Raycast(currentPosition, fireDirection, out hit, fireDistance))
        {
            //DETTE ER EN MEGA TEMP LØSNING!!!!!!!!!!!!!!
            if(hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy2"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy2").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy3"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy3").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy4"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy4").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy5"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy5").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy6"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
                
                GameObject.FindGameObjectWithTag("Enemy6").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy7"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
                
                GameObject.FindGameObjectWithTag("Enemy7").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy8"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy8").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy9"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy9").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy10"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy10").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy11"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy11").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy12"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy12").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy13"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy13").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy14"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy14").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy15"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy15").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy16"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
                
                GameObject.FindGameObjectWithTag("Enemy16").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy17"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy17").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy18"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy18").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy19"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy19").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy20"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy20").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy21"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy21").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy22"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy22").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy23"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
                
                GameObject.FindGameObjectWithTag("Enemy23").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy24"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy24").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy25"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy25").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy26"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
              
                GameObject.FindGameObjectWithTag("Enemy26").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy27"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
               
                GameObject.FindGameObjectWithTag("Enemy27").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy28"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
             
                GameObject.FindGameObjectWithTag("Enemy28").GetComponent<EnemyStats>().DoDamage();
            }
            if (hit.collider.CompareTag("Enemy29"))
            {
                Debug.Log("Hit enemy!");
                Destroy(gameObject);
            
                GameObject.FindGameObjectWithTag("Enemy29").GetComponent<EnemyStats>().DoDamage();
            }
            //SLUTT PÅ MEGA TEMP LØSNING!!!!!!!!!!!
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Hit wall!");

                Destroy(gameObject);

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>().AddMarker(hit.point);
            }

            if(hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Hit Ground");

                Destroy(gameObject);

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGun>().AddMarker(hit.point);
            }

        }
    }

    void MoveBullet()
    {
        float h = Time.fixedDeltaTime;
        IntegrationMethods.Heuns(h, currentPosition, currentVelocity, out newPosition, out newVelocity);
        CheckHit();

        currentPosition = newPosition;
        currentVelocity = newVelocity;
        transform.position = currentPosition;
    }

    void DestroyBullet()
    {
        if(transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }
}

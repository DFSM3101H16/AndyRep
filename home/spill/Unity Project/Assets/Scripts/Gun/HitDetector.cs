using UnityEngine;
using System.Collections;

public class HitDetector : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().DoDamage();
        }
    }
    
}

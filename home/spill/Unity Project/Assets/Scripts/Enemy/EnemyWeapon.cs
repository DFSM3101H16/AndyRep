using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

    public GameObject rockObj;
    public Transform rockParent;
    public Transform target;
    public GameObject hitMarker;
    public bool throwing;

    public static float weaponSpeed = 40f;
    // Use this for initialization
    void Start () {

	}

    void Update()
    {
        //WHEN TIME UPDATE THIS TO GRENADE/RIFLE
        ThrowRock();
    }

    void ThrowRock()
    {
        if(throwing)
        {
            GameObject newRock = Instantiate(rockObj, transform.position, transform.rotation) as GameObject;     
            newRock.GetComponent<Rock>().currentVelocity = weaponSpeed * transform.forward;
            throwing = false;
        }
    }

    public void AddMarker(Vector3 hitCoordinates)
    {
        Instantiate(hitMarker, hitCoordinates, Quaternion.identity);

        Vector3 localHitCoordinates = target.InverseTransformPoint(hitCoordinates);
    }

    public void DoThrow()
    {
        throwing = true;
    }
}

using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

    public Camera aimCamera;
    public GameObject bulletObj;
    public GameObject muzzle;
    public Transform targetEnemy;
    public GameObject hitMarker;

    public AudioClip[] gunShot;
    public AudioSource gunSource;

    public float bulletSpeed = 850f;
    public int ammo;

    bool canFire = true;

	// Use this for initialization
	void Start () {
        UnityEngine.Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ammo = 20;
	
	}
	
	// Update is called once per frame
	void Update () {
        FireBullet();
        ReloadGun();
        Aim();
        
	
	}

    void Aim()
    {
        if(Input.GetMouseButtonDown(1))
        {
            aimCamera.transform.localPosition += new Vector3(0.105f, -0.08f, 0.10f);
        }
        if(Input.GetMouseButtonUp(1))
        {
            aimCamera.transform.localPosition += new Vector3(-0.105f, 0.08f, -0.10f);
        }
    }

    void FireBullet()
    {
        if (ammo >= 1)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F) && canFire)
            {
                GameObject newBullet = Instantiate(bulletObj, muzzle.transform.position, muzzle.transform.rotation) as GameObject;

                newBullet.GetComponent<Bullet>().currentVelocity = bulletSpeed * muzzle.transform.forward;

                PlayShot();

                ammo--;

                canFire = false;
            }

            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.F))
            {
                canFire = true;
            }
        }
    }

    void ReloadGun()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammo = 20;
        }
    }

    public void AddMarker(Vector3 hitCoordinates)
    {
        Instantiate(hitMarker, hitCoordinates, Quaternion.identity);

        Vector3 localHitCoordinates = targetEnemy.InverseTransformPoint(hitCoordinates);
            
    }

    void PlayShot()
    {
        int randClip = Random.Range(0, gunShot.Length);
        gunSource.clip = gunShot[randClip];
        gunSource.Play();
    }
}

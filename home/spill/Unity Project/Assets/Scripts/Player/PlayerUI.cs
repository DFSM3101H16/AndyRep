using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    private PlayerStats pStats;
    private PlayerGun pGun;
    public Text HealthText;
    public Text AmmoText;

	// Use this for initialization
	void Start () {
        pStats = GetComponent<PlayerStats>();
        pGun = GetComponent<PlayerGun>();
	}
	
	// Update is called once per frame
	void Update () {
        if(pStats.dead)
        {
            Debug.Log("DEAD!!!!");
            DeadScene();
        }
        if(!pStats.dead)
        {
            HealthText.text = "Health: " + pStats.health;
            AmmoText.text = "Ammo: " + pGun.ammo;
        }
             	
	}

    void DeadScene()
    {
        SceneManager.LoadScene(2);
    }
}

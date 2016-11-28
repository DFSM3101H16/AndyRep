using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public AudioClip[] intro;
    public AudioSource introSource;


    // Use this for initialization
    void Start () {
        PlayIntro();

	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetMouseButtonDown(0))
        {
            PlayExplotion();
            SceneManager.LoadScene(1);
        }
	
	}

    void PlayIntro()
    {
        introSource.clip = intro[1];
        introSource.Play();
    }

    void PlayExplotion()
    {
        introSource.clip = intro[0];
        introSource.Play();
    }


}

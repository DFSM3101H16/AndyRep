using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CombatMusicControl : MonoBehaviour {

    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioMixerSnapshot inVictory;

    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 128;

    public AudioClip[] enemySounds;
    public AudioSource enemySource;

    public AudioClip[] playerSounds;
    public AudioSource playerSource;


    private float m_TransitionIn;
    private float m_TransitionOut;

    private float m_QuarterNote;


	// Use this for initialization
	void Start ()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CombatZone"))
        {
            inCombat.TransitionTo(m_TransitionIn);
            PlaySting();
        }

        if(other.CompareTag("EnemyZone"))
        {
            PlayEnemySound();
        }
        if(other.CompareTag("VictoryZone"))
        {
            inVictory.TransitionTo(m_TransitionIn);
            
        }

        if(other.CompareTag("QuoteZone"))
        {
            PlayPlayerSound();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CombatZone"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }

        if(other.CompareTag("VictoryZone"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }
    }

    void PlaySting()
    {
        int randClip = Random.Range(0, stings.Length);
        stingSource.clip = stings[randClip];
        stingSource.Play();
    }

    void PlayEnemySound()
    {
        int randClip = Random.Range(0, enemySounds.Length);
        enemySource.clip = enemySounds[randClip];
        enemySource.Play();
    }

    void PlayPlayerSound()
    {
        int randClip = Random.Range(0, playerSounds.Length);
        playerSource.clip = playerSounds[randClip];
        playerSource.Play();

    }
}
